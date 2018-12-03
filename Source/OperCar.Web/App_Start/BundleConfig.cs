﻿using System.Web.Optimization;

namespace OpeCar.OperCar.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /**********************************QUERYS************************************************************/
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.slim.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));
            /*************************PARTICLES**********************************/
            bundles.Add(new ScriptBundle("~/bundles/particles").Include(
                        "~/Scripts/particles/particles.js",
                        "~/Scripts/particles/js/app.js",
                        "~/Scripts/particles/js/lib/stats.js"
                        ));
            /***************************************************************/
            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                       "~/Scripts/home.js"));
            /*************************AREAS**********************************/
            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Scripts/areas/login.js"));



            /**********************************HOJAS DE ESTILOS***********************************************/
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/css/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/particles").Include(
                      "~/Content/css/particles/style.css"));
            bundles.Add(new StyleBundle("~/Content/general").Include(
                      "~/Content/css/general.css"));
            bundles.Add(new StyleBundle("~/Content/home").Include(
                      "~/Content/css/home.css"));
            /************************Areas*************************************/
            bundles.Add(new StyleBundle("~/Content/login").Include(
                      "~/Content/css/areas/login.css"));
        }
    }
}
