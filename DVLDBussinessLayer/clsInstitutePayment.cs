using System;
using System.Data;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsInstitutePayment
    {
        public int PaymentID { get; set; }
        public int InstituteID { get; set; }
        public int EnrollmentID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ChapaTransactionRef { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInstitutePayment()
        {
            this.PaymentID = -1;
            this.InstituteID = -1;
            this.EnrollmentID = -1;
            this.AmountPaid = 0;
            this.PaymentDate = DateTime.Now;
            this.ChapaTransactionRef = "";
            this.CreatedByUserID = -1;
        }

        public bool Save()
        {
            this.PaymentID = clsInstitutePaymentData.AddNewPayment(
                this.InstituteID, 
                this.EnrollmentID, 
                this.AmountPaid, 
                this.ChapaTransactionRef, 
                this.CreatedByUserID
            );
            return (this.PaymentID != -1);
        }

        public static DataTable GetPaymentsByInstituteID(int InstituteID)
        {
            return clsInstitutePaymentData.GetPaymentsByInstituteID(InstituteID);
        }
    }
}
