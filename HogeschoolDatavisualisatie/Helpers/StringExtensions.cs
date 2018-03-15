namespace HogeschoolDatavisualisatie.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method that converts string to int but the int can also be null
        /// </summary>
        /// <param name="item">String to be converted</param>
        /// <returns></returns>
        public static int? TryGetInt32(this string item)
        {
            int i;
            bool success = int.TryParse(item, out i);
            return success ? (int?)i : (int?)null;
        }
    }
}
