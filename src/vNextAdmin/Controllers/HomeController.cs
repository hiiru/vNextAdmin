using Microsoft.AspNet.Mvc;
using vNextAdminLib.Components.Common;
using vNextAdminLib.Components.Form;
using vNextAdminLib.Components.Dashboard;

namespace vNextAdmin.Controllers
{ 
    public class HomeController : AdminControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            var row = new Row();
            row.Children.Add(new CountPanel
            {
                IconCss = "comments",
                ColorCss = "primary",
                Count = 5,
                Message = "It's a test",
                LinkTarget = "#ok",
                LinkText = "Details"
            });
            row.Children.Add(new CountPanel
            {
                IconCss = "comments",
                ColorCss = "red",
                Count = 5,
                Message = "It's a test",
                LinkTarget = "#ok",
                LinkText = "Details"
            });
            row.Children.Add(new CountPanel
            {
                IconCss = "comments",
                ColorCss = "green",
                Count = 5,
                Message = "It's a test",
                LinkTarget = "#ok",
                LinkText = "Details"
            });
            row.Children.Add(new CountPanel
            {
                IconCss = "comments",
                ColorCss = "default",
                Count = 5,
                Message = "It's a test",
                LinkTarget = "#ok",
                LinkText = "Details"
            });


            return View("Test", row);
        }
        public IActionResult TestForm()
        {
            var form = new Form();
            form.Children.Add(new Input { Label = "Name", StatusText = "just ur damn. name !!!1111", Placholder = "your name here", Type = InputType.Text });
            form.Children.Add(new Input { Label = "Static thing", Type = InputType.Static, Value="it's E me, mario" });
            form.Children.Add(new Input { Label = "your life story", StatusText = "well, nobody cares anyway", Type = InputType.Textarea, Disabled = true });
            var checkboxes = new Option { Label = "chack this shit", Checkboxes = true, Inline = true };
            checkboxes.Values.Add("1", new OptionItem { Label = "first!!11", Checked = true });
            checkboxes.Values.Add("2", new OptionItem { Label = "too late", Disabled=true });
            checkboxes.Values.Add("3", new OptionItem { Label = "last one" });
            form.Children.Add(checkboxes);
            var radioboxes = new Option { Label = "choose" };
            radioboxes.Values.Add("1", new OptionItem { Label = "Option 1" });
            radioboxes.Values.Add("2", new OptionItem { Label = "Option B", Disabled = true });
            radioboxes.Values.Add("3", new OptionItem { Label = "Last Option", Checked = true});
            form.Children.Add(radioboxes);

            var select = new Select { Label = "Last item, select one" };
            select.Values.Add("1", new SelectItem { Label = "Option 1", Value = true });
            select.Values.Add("2", new SelectItem { Label = "Option B", Value = false, Disabled = true });
            select.Values.Add("3", new SelectItem { Label = "Last Option", Value = false, Selected=true });
            form.Children.Add(select);
            return View("Test", form);
        }
    }
}
