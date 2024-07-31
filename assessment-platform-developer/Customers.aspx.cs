using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using assessment_platform_developer.Services;
using Container = SimpleInjector.Container;

namespace assessment_platform_developer
{
    public partial class Customers : Page
    {
        private const string AddNewUserItemId = "new-user";
        private static List<Customer> customers = new List<Customer>();
        private ICustomerService customerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            customerService = testContainer.GetInstance<ICustomerService>();
            if (!IsPostBack)
            {

                customers = customerService.GetAllCustomers().ToList();
                ViewState["Customers"] = customers;
                PopulateCustomerPageDropDownLists();
                PopulateCustomerDropDownListBox();
                UpdateLocaleOptions();
            }
            else
            {
                customers = (List<Customer>)ViewState["Customers"];
            }
        }

        private void PopulateCustomerPageDropDownLists()
        {

            var countryList = Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .Select(c => new ListItem
                {
                    Text = c.ToString(),
                    Value = ((int)c).ToString()
                })
                .ToArray();

            CountryDropDownList.Items.AddRange(countryList);
            CountryDropDownList.SelectedValue = ((int)Countries.Canada).ToString();
        }

        protected void PopulateCustomerDropDownListBox()
        {
            CustomersDDL.Items.Clear();
            var storedCustomers = customers.Select(c => new ListItem(c.Name, c.ID.ToString())).ToArray();
            CustomersDDL.Items.Add(new ListItem("Add new customer", AddNewUserItemId));

            if (storedCustomers.Length != 0)
            {
                CustomersDDL.Items.AddRange(storedCustomers);
                CustomersDDL.SelectedValue = AddNewUserItemId;
            }

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                Name = CustomerName.Text,
                Address = CustomerAddress.Text,
                City = CustomerCity.Text,
                State = StateDropDownList.SelectedValue,
                Zip = CustomerZip.Text,
                Country = CountryDropDownList.SelectedValue,
                Email = CustomerEmail.Text,
                Phone = CustomerPhone.Text,
                Notes = CustomerNotes.Text,
                ContactName = ContactName.Text,
                ContactPhone = ContactPhone.Text,
                ContactEmail = ContactEmail.Text,
                ID = CustomersDDL.SelectedItem.Value.Equals(AddNewUserItemId) ? 0 : int.Parse(CustomersDDL.SelectedItem.Value),
            };

            if (CustomersDDL.SelectedItem.Value.Equals(AddNewUserItemId))
            {
                customerService.AddCustomer(customer);
                customers.Add(customer);

                CustomersDDL.Items.Add(new ListItem(customer.Name));
            }
            else
            {
                customerService.UpdateCustomer(customer);
            }

            ClearFormInputs();
        }

        private void ClearFormInputs()
        {
            CustomerName.Text = string.Empty;
            CustomerAddress.Text = string.Empty;
            CustomerEmail.Text = string.Empty;
            CustomerPhone.Text = string.Empty;
            CustomerCity.Text = string.Empty;
            CountryDropDownList.SelectedIndex = 0;
            UpdateLocaleOptions();
            StateDropDownList.SelectedIndex = 0;
            CustomerZip.Text = string.Empty;
            CustomerNotes.Text = string.Empty;
            ContactName.Text = string.Empty;
            ContactPhone.Text = string.Empty;
            ContactEmail.Text = string.Empty;
        }

        protected void CountryListChanged(Object obj, EventArgs e)
        {
            UpdateLocaleOptions(true);
        }
        protected void CustomerListChanged(Object obj, EventArgs e)
        {
            if (CustomersDDL.SelectedItem.Value.Equals(AddNewUserItemId))
            {
                //Clear the form if new user is being added
                ClearFormInputs();
                AddButton.Text = "Add";
            }
            else
            {
                var customerId = CustomersDDL.SelectedItem.Value;
                var customer = customerService.GetCustomer(int.Parse(customerId));

                CustomerName.Text = customer.Name;
                CustomerAddress.Text = customer.Address;
                CustomerEmail.Text = customer.Email;
                CustomerPhone.Text = customer.Phone;
                CustomerCity.Text = customer.City;
                CountryDropDownList.SelectedValue = customer.Country;
                UpdateLocaleOptions();
                StateDropDownList.SelectedValue = customer.State;
                CustomerZip.Text = customer.Zip;
                CustomerNotes.Text = customer.Notes;
                ContactName.Text = customer.ContactName;
                ContactPhone.Text = customer.ContactPhone;
                ContactEmail.Text = customer.ContactEmail;
                AddButton.Text = $"Update:{customer.Name}";
            }
        }
        private void UpdateLocaleOptions(bool triggerValidation = false)
        {
            var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
            var _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

            try
            {
                StateDropDownList.Items.Clear();
                StateDropDownList.Items.Add(new ListItem(""));

                //Set the list of states and the correct zipcode validations
                switch (CountryDropDownList.SelectedItem.Text)
                {
                    case "Canada":
                        ZipCodeRegularExpressionValidator.ValidationExpression = _caZipRegEx;

                        var _caProvinceList = Enum.GetValues(typeof(CanadianProvinces))
                            .Cast<CanadianProvinces>()
                            .Select(p => new ListItem
                            {
                                Text = p.ToString(),
                                Value = ((int)p).ToString()
                            })
                            .ToArray();
                        StateDropDownList.Items.AddRange(_caProvinceList);
                        break;
                    case "UnitedStates":
                        ZipCodeRegularExpressionValidator.ValidationExpression = _usZipRegEx;

                        var _usProvinceList = Enum.GetValues(typeof(USStates))
                            .Cast<USStates>()
                            .Select(p => new ListItem
                            {
                                Text = p.ToString(),
                                Value = ((int)p).ToString()
                            })
                            .ToArray();
                        StateDropDownList.Items.AddRange(_usProvinceList);
                        break;
                    default:
                        break;
                }

                //We dont need this to run on initial page load
                if (triggerValidation)
                    ZipCodeRegularExpressionValidator.Validate();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}