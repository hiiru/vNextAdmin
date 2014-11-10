using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using vNextAdminLib.Components;
using vNextAdminLib.Components.Common;
using vNextAdminLib.Components.Form;
using System.Threading.Tasks;

namespace vNextAdminLib.Resources
{
    public class TestAdminPage : IAdminResource
    {
        public TestAdminPage()
        {
            Model = new TestAdminPageModel();
        }
        public Form BuildForm(string errorName=null)
        {
            var formElement = new Form();
            var fieldsetLeft = new Fieldset { CssClasses = "col-xs-12 col-md-6" };
            var inputName = new Input { Label = "Pet name", Placholder = "Your pet's name", Type = InputType.Text, Name = "name" };
            if (errorName != null)
            {
                inputName.StatusText = "The name is missing!";
                inputName.Status = FormControlStatus.Error;
            }
            fieldsetLeft.Children.Add(inputName);
            var selectAnimal = new Select { Label = "Animal", StatusText = "What animal is your pet?", Name = "animal" };
            selectAnimal.Values.Add("", new SelectItem { Label = "Please choose...", Selected = true });
            selectAnimal.Values.Add("cat", new SelectItem { Label = "Cat" });
            selectAnimal.Values.Add("dog", new SelectItem { Label = "Dog" });
            selectAnimal.Values.Add("unicorn", new SelectItem { Label = "Unicorn", Disabled = true });
            selectAnimal.Values.Add("bird", new SelectItem { Label = "Bird" });
            fieldsetLeft.Children.Add(selectAnimal);
            fieldsetLeft.Children.Add(new Input { Label = "Pet Age", StatusText = "How old is your pet?", Type = InputType.Text, Name = "price" });
            var fieldsetRight = new Fieldset { Disabled = true, CssClasses = "col-xs-12 col-md-6" };
            fieldsetRight.Children.Add(new Input { Label = "Blackmarket Price", Type = InputType.Text, Name = "blackMarketPrice" });
            var optionPayment = new Option { Label = "Payment type", StatusText = "How do you like to get paid?", Checkboxes = false, Name = "payment" };
            optionPayment.Values.Add("1", new OptionItem { Label = "Bitcoin", Checked = true });
            optionPayment.Values.Add("2", new OptionItem { Label = "Paypal" });
            optionPayment.Values.Add("3", new OptionItem { Label = "Cash" });
            fieldsetRight.Children.Add(optionPayment);
            formElement.Children.Add(new Row { Children = { fieldsetLeft, fieldsetRight } });
            var row = new Row();
            row.Children.Add(new Button { Label = "Sell your Pet", Type = "submit", Name = "sell", ButtonCss = "btn btn-primary" });
            row.Children.Add(new Button { Label = "Run away before the cops get you", Type = "submit", Name = "run", ButtonCss = "btn btn-danger" });
            formElement.Children.Add(row);
            return formElement;
        }

        public List<IAdminPageItem> Get(QueryString qs)
        {
            var pageItems = new List<IAdminPageItem>();
            pageItems.Add(BuildForm());
            return pageItems;

        }
        public List<IAdminPageItem> Post(QueryString qs, IReadableStringCollection form)
        {
            var pageItems = new List<IAdminPageItem>();
            if (form.ContainsKey("run"))
            {
                pageItems.Add(new Alert { Status = AlertStatus.Info, Text = "You ran away, you're save now..." });
                return pageItems;
            }

            string errorName = null;
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(Model, new ValidationContext(Model), validationResults);
            if (isValid)
            {
                pageItems.Add(new Alert { Status = AlertStatus.Success, Text = string.Format("Thanks for selling your pet {0}!",Model.Name) });
                return pageItems;
            }
            var firstRow = new Row();
            pageItems.Add(firstRow);
            var formElement = BuildForm(validationResults[0].ErrorMessage);
            pageItems.Add(formElement);
            return pageItems;
        }

        public object HandleRequest(HttpContext context)
        {
            if (context.Request.Method == "POST")
            {
                var form = context.Request.GetFormAsync();
                return Post(context.Request.QueryString, form.Result);
            }
            else
            {
                return Get(context.Request.QueryString);
            }
        }

        public TestAdminPageModel Model { get; set; }

        public List<IAdminPageItem> PageItems { get; protected set; }

        public AdminResourceType Type { get { return AdminResourceType.AdminPage; } }

        public string Url { get { return "/Admin/Test"; } }

        public string ResourceName { get { return ""; } }

        public class TestAdminPageModel
        {
            [Required]
            public string Name { get; set; }
            public string Animal { get; set; }
            public int Age { get; set; }
            public decimal Price { get; set; }
            public int Payment { get; set; }

        }
    }
}