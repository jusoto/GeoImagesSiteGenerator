using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoPhotoSiteGenerator
{
    public partial class Form1 : Form
    {
        string title = "";
        string siteUrl = "";
        string outputFileName = "";
        string outputFileNameKml = "";
        string kmlBody = "";
        string apiKey = "";
        string initialCoordinates = "";

        public Form1()
        {
            InitializeComponent();
            txtTitle.Text = "Nepal Project";
            txtSiteUrl.Text = @"http://www.qicfixit.com:8080/nepal";
            txtPageFileName.Text = "index.html";
            txtKmlFileName.Text = "points.kml";
            txtInputFolder.Text = @"C:\Users\Juan\Desktop\TestHtmlGeoTagged\images";
            txtApiKey.Text = "AIzaSyAhOv2MNrliIM1BrBBOdgzD2Fip1rzUkHQ";
            txtInitialCoordinates.Text = "28.195258, 83.973013";
        }

        private void btnImageFolder_Click(object sender, EventArgs e)
        {
            showDialogFolder();
        }

        private void showDialogFolder()
        {
            if (fbdImages.ShowDialog() == DialogResult.OK)
            {
                txtInputFolder.Text = fbdImages.SelectedPath;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            title = txtTitle.Text;
            siteUrl = txtSiteUrl.Text;
            outputFileName = txtPageFileName.Text;
            outputFileNameKml = txtKmlFileName.Text;
            apiKey = txtApiKey.Text;
            initialCoordinates = txtInitialCoordinates.Text;

            string[] files = Directory.GetFiles(txtInputFolder.Text, "*.jpg");

            string html;
            string head;
            string body;
            string images;
            string containingFolder;
            string kml;
            

            head = getHead();
            body = getBodyHeader();
            images = "";
            containingFolder = getContainingFolder(files[0]);

            foreach (string filePath in files)
            {
                images += getImage(filePath, containingFolder);
                
            }

            body += images;
            body += getBodyFooter();

            html = "<html>" + head + body + "</html>";

            kml = getKml();


            CreateFile(html, outputFileName);
            CreateFile(kml, outputFileNameKml);
        }

        private void CreateFile(string html, string outputFileName)
        {
            string outputFilePath = getOutputFilePath(outputFileName);
            if (File.Exists(outputFilePath))
            {
                if(MessageBox.Show("The file " + outputFileName + " already exists. Do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(outputFileName);
                    
                }
            }
            File.WriteAllText(outputFilePath, html);
        }

        private string getContainingFolder(string filePath)
        {
            string containingFolder = "";

            string[] folders = txtInputFolder.Text.Split(Path.DirectorySeparatorChar);

            containingFolder = folders[folders.Length - 1];

            return containingFolder;
        }

        private string getOutputFilePath(string outputFileName)
        {
            string outputFilePath = "";

            string[] folders = txtInputFolder.Text.Split(Path.DirectorySeparatorChar);

            for (int i= 0; i < folders.Length-1; i++)
            {
                outputFilePath += folders[i] + Path.DirectorySeparatorChar;
            }

            outputFilePath += outputFileName;

            return outputFilePath;
        }

        private string getImage(string filePath, string containingFolder)
        {
            string image = "";
            string fileName;
            string location = getImageLocation(filePath);
            string kmlBodyAux = "";

            if (location != "")
            {
                string latitude = location.Split(',')[0];
                string longitude = location.Split(',')[1];
                string locationKml = longitude + "," + latitude;
                fileName = Path.GetFileName(filePath);

                image = "<li><a href='#' class='pan-to-marker' data-marker-lat='[latitude]' data-marker-lng='[longitude]' data-content=\"<img src='" + siteUrl + "/[containingFolder]/[name]' title='[title]' height='450'>\">" +@"
<img src='" + siteUrl + @"/[containingFolder]/thumbs/[name]' title='[title]' height='100'>
				</a></li>";

                image = image.Replace("[containingFolder]", containingFolder);
                image = image.Replace("[name]", fileName);
                image = image.Replace("[title]", fileName);
                image = image.Replace("[latitude]", latitude);
                image = image.Replace("[longitude]", longitude);
                image = image.Replace("[location]", location);

                kmlBodyAux = @"<Placemark>
      <name>[name]</name>
      <styleUrl>#style</styleUrl>
      <ExtendedData>
        <Data name='image'>
          <value><![CDATA[<img src='" + siteUrl + @"/[containingFolder]/[name]' title='[title]' height='450'>]]></value>
        </Data>
      </ExtendedData>
      <Point>
        <coordinates>[locationKml],0</coordinates>
      </Point>
    </Placemark>";

                kmlBodyAux = kmlBodyAux.Replace("[containingFolder]", containingFolder);
                kmlBodyAux = kmlBodyAux.Replace("[name]", fileName);
                kmlBodyAux = kmlBodyAux.Replace("[title]", fileName);
                kmlBodyAux = kmlBodyAux.Replace("[locationKml]", locationKml);

            }

            kmlBody += kmlBodyAux;

            return image;

        }

        private string getBodyHeader()
        {
            string bodyHead;
            
            bodyHead= @"<body>
  <div class='container'>
    <div class='pageTitle'>" + title + @"</div>
      <div>
        <div id='map'></div>
        <div id='capture'></div>
      </div>
      <div class='container'>
        <ul class='images'>";

            return bodyHead;
        }

        private string getBodyFooter()
        {
            string bodyFooter;

            bodyFooter = @"      </ul>
    </div>
  </div>
</body>
";

            return bodyFooter;
        }

        private string getHead()
        {
            //ADD API to Production ?key=AIzaSyAhOv2MNrliIM1BrBBOdgzD2Fip1rzUkHQ
            string head = @"<head>
  <title>"+ title + @"</title>
  <style>
body {
	background-color: #ffffff;
    margin: 0px;
}

.container {
	width: 1010px;
	max-width: 100%;
	padding-top: 10px;
    text-align: center;
}

#map {
  height: 450px;
  width: 450px;
  max-width: 100%;
  overflow: hidden;
  float: left;
  border: thin solid #333;
  border-right: thick solid #ccc;
}

#capture {
  height: 450px;
  width: 450px;
  max-width: 100%;
  overflow: hidden;
  /*float: left;*/
  background-color:#ECECFB;
  border: thin solid #333;
  border-left: none;
  text-align:center;
}

ul.images {
  margin: 0;
  padding: 5;
  white-space: nowrap;
  width: 1000px;
  max-width: 100%;
  overflow-x: auto;
  background-color: #ddd;
}

ul.images li {
  display: inline;
  width: 150px;
  height: 150px;
}

.thumbnail {
	width: 1px;
	text-align: center;
	border: 1px solid #dddddd;
}

.pageTitle {
	text-align: center;
	font-size: 18px;
	font-weight: bold;
    padding-bottom: 10px;
}

.pageDescription {
	font-size: 12px;
	line-height: 140%;
	text-align: justify;
	padding-left: 0px;
	padding-right: 0px;
}

.imageDescription {
	vertical-align: top;
	horizontal-align: left;
	font-size: 11px;
	line-height: 120%;
	border: 1px solid #dddddd;
}

span.imageTitle {
	font-size: 14px;
	font-weight: bold;
}

span.mapLinks {
	font-family: Arial;
	font-size: 10px;
}
  </style>
  <script src='https://maps.googleapis.com/maps/api/js[apiKey]'></script>
  <script src='https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js'></script>
  <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery.lazyload/1.9.1/jquery.lazyload.min.js'></script>
  <script>
    var map;
    var src = 'http://www.qicfixit.com:8080/nepal/points.kml' + '?rand='+(new Date()).valueOf();
	
	$(document).on('click', '.pan-to-marker', function(e) {
	  e.preventDefault();
	
	  var lat, lng;
	  var $lat = $(this).data('marker-lat');
	  var $lng = $(this).data('marker-lng');
	  var $content = $(this).data('content');
	  lat = $lat;
	  lng = $lng;
	  map.setCenter(new google.maps.LatLng(lat, lng));
	  var testimonial = document.getElementById('capture');
	  testimonial.innerHTML = $content;
	});

	function initialize() {
	  map = new google.maps.Map(document.getElementById('map'), {
		center: new google.maps.LatLng([initialCoordinates]),
		zoom: 7,
		mapTypeId: google.maps.MapTypeId.SATELLITE
	  });
	  loadKmlLayer(src, map);
	}

	function loadKmlLayer(src, map) {
	  var kmlLayer = new google.maps.KmlLayer(src, {
	  suppressInfoWindows: true,
	  preserveViewport: false,
	  map:map
	});
	
	  google.maps.event.addListener(kmlLayer, 'click', function(event) {
		var content = event.featureData.infoWindowHtml;
		var testimonial = document.getElementById('capture');
		testimonial.innerHTML = content;
	  });
	}

    google.maps.event.addDomListener(window, 'load', initialize);
  </script>
</head>";
            head = head.Replace("[apiKey]", "?key="+apiKey);
            head = head.Replace("[initialCoordinates]", initialCoordinates);

            return head;
        }

        public string getImageLocation(string filePath)
        {
            string location = "";
            ASCIIEncoding encoding = new ASCIIEncoding();
            //string item;

            // Create an Image object. 
            Image image = new Bitmap(@filePath);

            // Get the PropertyItems property from image.
            PropertyItem[] propItems = image.PropertyItems;

            double latitude = GetLatitude(image);//get Latitude info
            double longitude = GetLongitude(image);//get Longitude info

            if (latitude > 0 && longitude > 0)
            {
                location = latitude + "," + longitude;
            }

            //Dispose image to free resources
            image.Dispose();

            return location;
        }

        //read Latitude info from image file
        public static double GetLatitude(Image targetImg)
        {
            try
            {
                //Property Item 0x0001 - PropertyTagGpsLatitudeRef
                PropertyItem propItemRef = targetImg.GetPropertyItem(1);
                //Property Item 0x0002 - PropertyTagGpsLatitude
                PropertyItem propItemLat = targetImg.GetPropertyItem(2);
                //convert image metadatada properties into latitude
                return ExifGpsToDouble(propItemRef, propItemLat);
            }
            catch (ArgumentException)
            {
                //return 0 if there is no GPS properties in image
                return 0;
            }
        }

        public static double GetLongitude(Image targetImg)
        {
            try
            {
                ///Property Item 0x0003 - PropertyTagGpsLongitudeRef
                PropertyItem propItemRef = targetImg.GetPropertyItem(3);
                //Property Item 0x0004 - PropertyTagGpsLongitude
                PropertyItem propItemLong = targetImg.GetPropertyItem(4);
                //convert image metadatada properties into longitude
                return ExifGpsToDouble(propItemRef, propItemLong);
            }
            catch (ArgumentException)
            {
                //return 0 if there is no GPS properties in image
                return 0;
            }
        }

        //Calculation needed to transform metadata properties into GPS decimal number
        //source: http://stackoverflow.com/questions/4983766/getting-gps-data-from-an-images-exif-in-c-sharp
        private static double ExifGpsToDouble(PropertyItem propItemRef, PropertyItem propItem)
        {
            uint degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            uint degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            float degrees = degreesNumerator / (float)degreesDenominator;

            uint minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            uint minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            float minutes = minutesNumerator / (float)minutesDenominator;

            uint secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            uint secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            float seconds = secondsNumerator / (float)secondsDenominator;

            float coorditate = degrees + (minutes / 60f) + (seconds / 3600f);
            string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, S, E, or W
            if (gpsRef == "S" || gpsRef == "W")
                coorditate = 0 - coorditate;
            return coorditate;
        }

        private string getKml()
        {
            string kmlHead;
            string kmlFooter;
            string kml;


            kmlHead = getKmlHead();
            kmlFooter = getKmlFooter();

            kml = kmlHead + kmlBody + kmlFooter;

            return kml;

        }

        private string getKmlFooter()
        {
            string kmlFooter = @"  </Document></kml>";

            return kmlFooter;
        }

        private string getKmlHead()
        {
            string kmlHead = @"<?xml version='1.0' encoding='UTF-8'?>
<kml xmlns = 'http://www.opengis.net/kml/2.2'><Document>
     <name>KmlFile</name>
     <Style id='style'>
        <IconStyle>
          <Icon>
            <href>images/pin-icon.png
            </href>
          </Icon>
        </IconStyle>
        <BalloonStyle>
          <text>$[image]</text>
      </BalloonStyle>
    </Style>";

            return kmlHead;
        }


    }
}
