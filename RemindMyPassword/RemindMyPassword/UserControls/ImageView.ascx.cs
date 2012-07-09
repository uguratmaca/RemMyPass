using System.Web.UI;
using DataLayer;

namespace RemindMyPassword
{
    public partial class ImageView : UCBase
    {
        public string my_imageLink = string.Empty;

        protected void ShownLinkImage_click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(my_imageLink))
            {
                Session[Constants.S_ErrorMessage] = "NoImageLink";
                Response.Redirect("~/Error.aspx");
            }
            else
            {
                Response.Redirect(my_imageLink);
            }
        }

        public void SetProperties(string imageLink, string imageUrl = "~/Images/not_found.jpg",
            int width = 150, int height = 150)
        {
            my_imageLink = imageLink;
            ShownLinkImage.ImageUrl = imageUrl;
            ShownLinkImage.Width = width;
            ShownLinkImage.Height = height;
            //ShownLinkImage.ImageAlign = imageAline;ImageAlign imageAline = ImageAlign.Baseline,
        }
    }
}