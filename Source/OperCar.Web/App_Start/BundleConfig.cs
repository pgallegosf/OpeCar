using System.Web.Optimization;

namespace OpeCar.OperCar.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /**********************************QUERYS************************************************************/
            bundles.Add(new ScriptBundle("~/bundles/jquerySlim").Include(
                        "~/Scripts/jquery-3.3.1.slim.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.min.js"));
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
            bundles.Add(new ScriptBundle("~/bundles/aplicacion").Include(
                        "~/Scripts/areas/aplicacion.js"));
            bundles.Add(new ScriptBundle("~/bundles/sig").Include(
                        "~/Scripts/areas/sig.js"));
            bundles.Add(new ScriptBundle("~/bundles/gestionDocumentaria").Include(
                        "~/Scripts/areas/gestionDocumentaria.js"));
            bundles.Add(new ScriptBundle("~/bundles/sigDetalle").Include(
                        "~/Scripts/areas/sigDetalle.js"));
            bundles.Add(new ScriptBundle("~/bundles/seguridad").Include(
                        "~/Scripts/areas/seguridad.js"));
            bundles.Add(new ScriptBundle("~/bundles/organizacion").Include(
                        "~/Scripts/areas/organizacion.js"));
            bundles.Add(new ScriptBundle("~/bundles/log").Include(
                        "~/Scripts/areas/log.js"));
            bundles.Add(new ScriptBundle("~/bundles/menu_organizacion").Include(
                        "~/Scripts/menu_organizacion.js"));


            /**********************************HOJAS DE ESTILOS***********************************************/
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/css/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/particles").Include(
                      "~/Content/css/particles/style.css"));
            bundles.Add(new StyleBundle("~/Content/general").Include(
                      "~/Content/css/general.css"));
            bundles.Add(new StyleBundle("~/Content/home").Include(
                      "~/Content/css/home.css"));
            bundles.Add(new StyleBundle("~/Content/animate").Include(
                      "~/Content/css/animate.css"));
            /************************Areas*************************************/
            bundles.Add(new StyleBundle("~/Content/login").Include(
                      "~/Content/css/areas/login.css"));
            bundles.Add(new StyleBundle("~/Content/css/areas/organizacion").Include(
                      "~/Content/css/areas/organizacion.css"));
            bundles.Add(new StyleBundle("~/Content/sig").Include(
                      "~/Content/css/areas/sig.css"));
            bundles.Add(new StyleBundle("~/Content/sigDetalle").Include(
                      "~/Content/css/areas/sigDetalle.css"));

         
        }
    }
}
