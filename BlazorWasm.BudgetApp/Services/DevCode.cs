using System.Security.Cryptography;
using System.Text;
using ColorMine.ColorSpaces;

namespace BlazorWasm.BudgetApp
{
    public static class DevCode
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return str == null || string.IsNullOrEmpty(str.Trim());
        }

        public static List<T> ToPage<T>(this List<T> lst, int pageNo, int pageSize)
        {
            int skipRowCount = (pageNo - 1) * pageSize;
            return lst.Skip(skipRowCount).Take(pageSize).ToList();
        }
        
        public static string ToHexColor(this string inputText)
        {
            inputText = "hexcolor-" + inputText +"-hexcolor";
            // Convert the input text to a byte array
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputText);

            // Compute the hash of the input bytes
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Take the first three bytes of the hash and use them as the RGB values
                byte red = hashBytes[0];
                byte green = hashBytes[1];
                byte blue = hashBytes[2];

                // Convert the RGB values to a hex color code
                string hexColor = $"#{red:X2}{green:X2}{blue:X2}";

                // return hexColor;
                // Convert the hex color to an RGB color
                var rgb = new Rgb
                {
                    R = byte.Parse(hexColor.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                    G = byte.Parse(hexColor.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                    B = byte.Parse(hexColor.Substring(5, 2), System.Globalization.NumberStyles.HexNumber)
                };

                // Convert the RGB color to an HSL color
                var hsl = rgb.To<Hsl>();

                // Generate the accent color by modifying the HSL color
                var accentHsl = new Hsl
                {
                    H = hsl.H,
                    S = hsl.S * 1.35, // Increase saturation by 35%
                    L = hsl.L * 0.56 // Reduce lightness by 44%
                };

                // Convert the accent HSL color back to an RGB color
                var accentRgb = accentHsl.To<Rgb>();

                int h = Convert.ToInt32(accentRgb.R.Remove());
                int s = Convert.ToInt32(accentRgb.G.Remove());
                double b = accentRgb.B.Remove();
                double b2 = b.ToLessThan(30);
                s += Convert.ToInt32(b > 30 ? b2 - b : 0);
                int l = Convert.ToInt32(b2);
                l = 40;
                // Return the accent color as a string in the --accent: H S% L%; format
                return $"{h} {s}% {l}%;";
            }
        }

        private static double Remove(this double d)
        {
            return d < 0 ? d * - 1 : d;
        }
        
        public static double ToLessThan(this double str, int lessThanNum)
        {
            int num = Convert.ToInt32(str);
            if(num > lessThanNum)
            {
                return ToLessThan(num-1, lessThanNum);
            }

            return num;
        }
    }
}
