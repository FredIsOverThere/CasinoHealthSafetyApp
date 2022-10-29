using CasinoHSApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoHSApp.Data
{

		public static class PickerStrings
	    {
			public static IList<SearchPicker> SearchPickers { get; private set; }
            public static IList<TeamPicker> TeamPickers { get; private set; }

            static PickerStrings()
            {
                SearchPickers = new List<SearchPicker>();
                SearchPickers.Add(new SearchPicker()
                {
                    SearchCriteria="Staff ID"
                });
                SearchPickers.Add(new SearchPicker()
                {
                    SearchCriteria="First Name"
                });
                SearchPickers.Add(new SearchPicker()
                {
                    SearchCriteria="Last Name"
                });
                TeamPickers = new List<TeamPicker>();
                TeamPickers.Add(new TeamPicker()
                {
                    Team="Premium"
                });
                TeamPickers.Add(new TeamPicker()
                {
                    Team="Main Floor"
                });

            }


        }

}
