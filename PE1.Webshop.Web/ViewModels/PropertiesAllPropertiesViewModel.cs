﻿namespace PE1.Webshop.Web.ViewModels
{
    public class PropertiesAllPropertiesViewModel
    {
        public IEnumerable<PropertiesPropertyDetailsViewModel> AllProperties { get; set; }

        public PropertiesAllPropertiesViewModel()
        {
            AllProperties = new List<PropertiesPropertyDetailsViewModel>();
        }
    }
}
