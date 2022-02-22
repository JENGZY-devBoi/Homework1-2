using System;

namespace Homework1_2 {
    public static class CitizenUtil {
        public static bool ValidateFormat(string id) {
            string[] arrID = id.Split('-');

            // Check string number
            bool isNOTNum = false;
            bool isExceedLen = false;
            int[] len = { 1, 4, 5, 2, 1 }; // Format ID : #-####-#####-##-#
            int i = 0;
            foreach (var itm in arrID) {
                // Check all terms of array are can conversion to integer
                int x = 0;
                if (!int.TryParse(itm, out x)) {
                    isNOTNum = true;
                    break;
                }

                // Check the size of each array.
                if (itm.Length != len[i]) {
                    isExceedLen = true;
                    break;
                }
                i++;
            }

            if ((arrID.Length != 5) || (isNOTNum) || (isExceedLen)) {
                return false;
            } else return true;
        }

        public static void GetBasicInfo(string id) {
            if (!ValidateFormat(id)) {
                throw new FormatException();
            }
        }
    }
}