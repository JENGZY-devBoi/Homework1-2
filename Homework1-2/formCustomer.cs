using System;
using System.Windows.Forms;

namespace Homework1_2 {
    public partial class formCustomer : Form {
        private string strCusGroup;
        public string[] _arrProvince =
        {"กรุงเทพมหานคร", "กระบี", "กาญจนบุรี", "กาฬสินธุ์", "กำแพงเพชร",
             "ขอนแก่น", "จันทบุรี", "ฉะเชิงเทรา", "ชลบุรี", "ชัยนาท", "ชัยภูมิ", "ชุมพร",
             "เชียงราย", "เชียงใหม่", "ตรัง", "ตราด", "ตาก", "นครนายก", "นครปฐม", "นครพนม",
             "นครราชสีมา", "นครศรีธรรมราช", "นครสวรรค์", "นนทบุรี", "นราธิวาส", "น่าน", "บึงกาฬ",
             "บุรีรัมย์", "ปทุมธานี", "ประจวบคีรีขันธ์", "ปราจีนบุรี", "ปัตตานี", "พระนครศรีอยุธยา", "พังงา",
             "พัทลุง", "พิจิตร", "พิษณุโลก", "เพชรบุรี", "เพชรบูรณ์", "แพร่", "พะเยา", "ภูเก็ต", "มหาสารคาม",
             "มุกดาหาร", "แม่ฮ่องสอน", "ยะลา", "ยโสธร", "ร้อยเอ็ด", "ระนอง" , "ระยอง", "ราชบุรี", "ลพบุรี",
             "ลำปาง", "ลำพูน", "เลย", "ศรีสะเกษ", "สกลนคร", "สงขลา", "สตูล", "สมุทรปราการ", "สมุทรสงคราม",
             "สมุทรสาคร", "สระแก้ว", "สระบุรี", "สิงห์บุรี", "สุโขทัย", "สุพรรณบุรี", "สุราษฎร์ธานี", "สุรินทร์",
             "หนองคาย", "หนองบัวลำภู", "อ่างทอง", "อุดรธานี", "อุทัยธานี", "อุตรดิตถ์", "อุบลราชธานี", "อำนาจเจริญ"
        };

        public formCustomer() {
            InitializeComponent();
            dtCusDOB.Value = DateTime.Today;
            dtCusDOB.CustomFormat = "M/d/yyyy";
            dtCusDOB.Format = DateTimePickerFormat.Custom;
        }

        private void comboCusGroup_SelectedIndexChanged(object sender, EventArgs e) {
            textCusCode.Text = "";
            strCusGroup = textCusCode.Text = comboCusGroup.SelectedItem.ToString() + textCusID.Text;
        }

        private void textCusID_TextChanged(object sender, EventArgs e) {
            textCusCode.Text = strCusGroup + textCusID.Text;
        }

        private void textCusPrefixCode_TextChanged(object sender, EventArgs e) {
            int num = 0;
            if (textCusPrefixCode.Text == "") textCusPrefix.Text = "";
            if ((!int.TryParse(textCusPrefixCode.Text, out num) || num < 1 || num > 4) && textCusPrefixCode.Text != "") {
                MessageBox.Show("กรุณาใส่ข้อมูลเป็นจำนวนเต็มระหว่าง1-4");
                textCusPrefixCode.Text = "";
                textCusPrefix.Text = "";
                return;
            }
            textCusPrefix.ReadOnly = true;

            if (num == 1) textCusPrefix.Text = "นาย";
            if (num == 2) textCusPrefix.Text = "นาง";
            if (num == 3) textCusPrefix.Text = "นางสาว";
            if (num == 4) {
                textCusPrefix.Text = "";
                textCusPrefix.ReadOnly = false;
            }
        }

        private void textCusProvinceCode_TextChanged(object sender, EventArgs e) {
            int num = 0;
            if ((!int.TryParse(textCusProvinceCode.Text, out num) || num < 1 || num > 77) && textCusProvinceCode.Text != "") {
                MessageBox.Show("กรุณาใส่ข้อมูลเป็นจำนวนเต็มระหว่าง1-77");
                textCusProvinceCode.Text = "";
                return;
            }

            try {
                --num;
                textCusProvince.Text = _arrProvince[num];
            } catch (IndexOutOfRangeException) {
                textCusProvince.Text = "";
            }
        }

        private void buttonGetInfoFromCitizenID_Click(object sender, EventArgs e) {
            try {
                CitizenUtil.GetBasicInfo(textCusCitizenID.Text);
                MessageBox.Show(
                    $"ID number : {textCusCitizenID.Text}\n" +
                    $"{textCusPrefix.Text} {textCusName.Text} {textCusLastName.Text} \n" +
                    $"Date of Birth : {dtCusDOB.Text} \n" +
                    $"Address : \n{textCusHouseNumber.Text} {textCusMoo.Text} {textCusSoi.Text} " +
                    $"{textCusRoad.Text} {textCusSubDistrict.Text} {textCusDistrict.Text} {textCusProvince.Text}"
                );
            }catch(FormatException) {
                MessageBox.Show("Please type x-xxxx-xxxxx-xx-x");
            }
        }
    }
}