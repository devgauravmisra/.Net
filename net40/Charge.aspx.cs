using Razorpay.Api;
using System;
using System.Collections.Generic;

namespace RazorpaySampleApp
{
    public partial class Charge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
                    string paymentId = Request.Form["razorpay_payment_id"];
                    string orderId = Request.Form["razorpay_order_id"];
                    string signature = Request.Form["razorpay_signature"];


                    string key = "rzp_test_Ds7nLlw2c0Flgb";
                    string secret = "tfjeAExzVHGoMQ9zDeM5Ae82";

                    RazorpayClient client = new RazorpayClient(key, secret);

                 
                    Dictionary<string, string> attributes = new Dictionary<string, string>();
               
                    attributes.Add("razorpay_payment_id", paymentId);
                    attributes.Add("razorpay_order_id", orderId);
                    attributes.Add("razorpay_signature", signature);

                    Utils.verifyPaymentSignature(attributes);

                    pTxnId.InnerText = paymentId;
                    pOrderId.InnerText = orderId;
                    h1Message.InnerText = "Transaction Successful";
        }
        catch(Exception)
        {
           h1Message.InnerText = "Transaction UnSuccessful";
        }

//             please use the below code to refund the payment 
//             Refund refund = new Razorpay.Api.Payment((string) paymentId).Refund();

           // Console.WriteLine(paymentId);
        }
    }
}
