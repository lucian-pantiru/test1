using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using DXGrid.F1Models;

namespace DXGrid.Models {
    // DXCOMMENT: Configure a data model (In this sample, we do this in file NorthwindDataProvider.cs. You would better create your custom file for a data model.)
    public static class NorthwindDataProvider {
        const string NorthwindContextKey = "DXNorthwindContext";

        public static Model1 DB {
            get {
                if (HttpContext.Current.Items[NorthwindContextKey] == null)
                    HttpContext.Current.Items[NorthwindContextKey] = new Model1();
                return (Model1)HttpContext.Current.Items[NorthwindContextKey];
            }
        }

        public static IEnumerable GetTeams() {
            return DB.Teams.ToList();
        }
    }
}