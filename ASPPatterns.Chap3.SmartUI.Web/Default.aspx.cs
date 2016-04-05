using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPPatterns.Chap3.SmartUI.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var RRP = decimal.Parse(((System.Data.DataRowView)e.Row.DataItem)["RRP"].ToString());
                var SellingPrice = decimal.Parse(((System.Data.DataRowView)e.Row.DataItem)["SellingPrice"].ToString());

                var lblSavings = (Label)e.Row.FindControl("lblSavings");
                var lblDiscount = (Label)e.Row.FindControl("lblDiscount");
                var lblSellingPrice = (Label)e.Row.FindControl("lblSellingPrice");

                lblSavings.Text = DisplaySavings(RRP, ApplyExtraDiscountsTo(SellingPrice));
                lblDiscount.Text = DisplayDiscount(RRP, ApplyExtraDiscountsTo(SellingPrice));
                lblSellingPrice.Text = string.Format("{0:C}", ApplyExtraDiscountsTo(SellingPrice));
            }
        }

        protected string DisplayDiscount(decimal RRP, decimal SalePrice)
        {
            return RRP > SalePrice ? string.Format("{0:C}", (RRP - SalePrice)) : string.Empty;
        }

        protected string DisplaySavings(decimal RRP, decimal SalePrice)
        {
            return RRP > SalePrice ? (1 - (SalePrice / RRP)).ToString("#%") : string.Empty;
        }

        protected decimal ApplyExtraDiscountsTo(decimal originalSalePrice)
        {
            decimal price = originalSalePrice;
            int discountType = Int16.Parse(this.ddlDiscountType.SelectedValue);

            if(discountType == 1)
            {
                price = price * 0.95M;
            }

            return price;
        }

        protected void ddlDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
    }
}