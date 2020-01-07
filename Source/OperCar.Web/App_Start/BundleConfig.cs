using System.Web.Optimization;

namespace OpeCar.OperCar.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

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
            
            // FroalaEditor css
            bundles.Add(new StyleBundle("~/Content/FroalaEditor").Include(                      
                      "~/Content/plugins/froala_editor/css/froala_editor.css",
                      "~/Content/plugins/froala_editor/css/froala_style.css",
                      "~/Content/plugins/froala_editor/css/plugins/code_view.css",
                      "~/Content/plugins/froala_editor/css/plugins/colors.css",
                      "~/Content/plugins/froala_editor/css/plugins/emoticons.css",
                      "~/Content/plugins/froala_editor/css/plugins/image_manager.css",
                      "~/Content/plugins/froala_editor/css/plugins/image.css",
                      "~/Content/plugins/froala_editor/css/plugins/line_breaker.css",
                      "~/Content/plugins/froala_editor/css/plugins/table.css",
                      "~/Content/plugins/froala_editor/css/plugins/char_counter.css",
                      "~/Content/plugins/froala_editor/css/plugins/video.css",
                      "~/Content/plugins/froala_editor/css/plugins/fullscreen.css",
                      "~/Content/plugins/froala_editor/css/plugins/file.css",
                      "~/Content/plugins/froala_editor/css/themes/gray.css"
             ));
            // FroalaEditor js
            bundles.Add(new ScriptBundle("~/bundles/FroalaEditor").Include(
                        "~/Content/plugins/froala_editor/js/froala_editor.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/align.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/code_beautifier.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/code_view.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/colors.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/draggable.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/emoticons.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/font_size.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/font_family.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/image.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/file.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/image_manager.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/line_breaker.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/link.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/lists.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/paragraph_format.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/paragraph_style.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/video.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/table.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/url.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/entities.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/char_counter.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/inline_style.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/save.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/fullscreen.min.js",
                        "~/Content/plugins/froala_editor/js/plugins/quote.min.js",
                        "~/Content/plugins/froala_editor/js/languages/es.js"));

            bundles.Add(new ScriptBundle("~/bundles/Mantenimiento").Include(
                       "~/Scripts/areas/mantenimiento.js"));
        }
    }
}
