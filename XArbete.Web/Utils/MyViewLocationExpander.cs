using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

public class MyViewLocationExpander : IViewLocationExpander
{

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
        IEnumerable<string> viewLocations)
    { 
        viewLocations = viewLocations.Append("/Features/{1}/Views/{0}.cshtml");
        viewLocations = viewLocations.Append("/Features/{1}/Views/PartialViews/{0}.cshtml");
        viewLocations = viewLocations.Append("/Features/{0}.cshtml");
        viewLocations = viewLocations.Append("/Features/Admin/{1}/Views/{0}.cshtml");
        viewLocations = viewLocations.Append("/Features/Admin/{1}/Views/PartialViews/{0}.cshtml");

     
        return viewLocations;
    }
   

    public void PopulateValues(ViewLocationExpanderContext context)
    {
        //nothing to do here.  
    }
}