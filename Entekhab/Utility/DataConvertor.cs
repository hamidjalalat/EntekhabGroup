using Entekhab.Request;
using FluentResults;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Entekhab.Utility
{
    public static class DataConvertor
    {

        public static Data DeserializeXmlToObject(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Data));
            Data result;

            try
            {
                using (TextReader reader = new StringReader(data))
                {
                    result = (Data)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                throw new Exception("فرمت داده صحیح نمی باشد");
            }

            return result;
        }

        public static Data DeserializeJsonToObject(string data)
        {
            Data result;

            try
            {
                result = JsonSerializer.Deserialize<Data>(json: data, options: null);
            }
            catch (Exception)
            {
                throw new Exception("فرمت داده صحیح نمی باشد");
            }
            return result;
        }

        public static Data DeserializeCsvToObject(string data)
        {
            string[] values = data.Split('/');
            Data result = new Data();
            try
            {
                result.FirstName = values[0];
                result.LastName = values[1];
                result.BasicSalary = Convert.ToDecimal(values[2]);
                result.Allowance = Convert.ToDecimal(values[3]);
                result.Transportation = Convert.ToDecimal(values[4]);
                result.Date = values[5];
            }
            catch (Exception)
            {
                throw new Exception("فرمت داده صحیح نمی باشد");
            }


            return result;
        }

        public static Data DeserializeCustomToObject(string data)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] splitData = data.Split(stringSeparators, StringSplitOptions.None);

            string[] field = splitData[0].Split('/');
            string[] values = splitData[1].Split('/');

            StringBuilder jsonBuilder = new StringBuilder();

            for (int i = 0; i < field.Length; i++)
            {
                try
                {

                    decimal value = decimal.Parse(values[i]);

                    if (field[i] == "Date")
                    {
                        jsonBuilder.Append("\"" + field[i] + "\"" + ":" + "\"" + values[i] + "\",");
                    }
                    else
                    {
                        jsonBuilder.Append("\"" + field[i] + "\"" + ":" + values[i] + ",");
                    }
                }
                catch (Exception)
                {
                    jsonBuilder.Append("\"" + field[i] + "\"" + ":" + "\"" + values[i] + "\",");
                }

            }

            string json = jsonBuilder.ToString().Remove(1, 1).Remove(jsonBuilder.Length - 2, 1); ;
            json = "{" + json + "}";

            Data result = new Data();

            try
            {
                result = DeserializeJsonToObject(json);

            }
            catch (Exception)
            {
                throw new Exception("فرمت داده صحیح نمی باشد");
            }

            return result;
        }
    }
}
