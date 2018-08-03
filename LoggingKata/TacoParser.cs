using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    //33.858498,-84.60189
    /*This method is used to parse a single row from your CSV file as a string and return an ITrackable: */
    /* // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
    var cells = line.Split(',');
 */
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
           
            logger.LogInfo(line);

            var cells = line.Split(',');

            string lattitude = cells[0];
            string longitude = cells[1];
            string name = cells[2];

            double longpoint = double.Parse(longitude);
            double latpoint = double.Parse(lattitude);
            
            Point point = new Point();
            point.Longitude = longpoint;
            point.Latitude = latpoint;

            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;

            if (cells.Length < 3)
            {
                logger.LogWarning(line);

                return null;
            }

            return tacoBell;


            // Do not fail if one record parsing fails, return null
            // TODO Implement
            /*  if (cells.Length < 3)
                 {
                     logger.LogWarning(line);

                     return null;
                 }

             //more loops to account for nulls */


        }
    }
}