using System.Web;
using System.Web.Optimization;

namespace Clinvet {
    public class BundleConfig {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new ScriptBundle("~/assets/bundles/js").Include(
                        "~/assets/bundles/libscripts.bundle.js",
                        "~/assets/bundles/vendorscripts.bundle.js",
                        "~/assets/bundles/morrisscripts.bundle.js",
                        "~/assets/bundles/jvectormap.bundle.js",
                        "~/assets/plugins/jvectormap/jquery-jvectormap-us-aea-en.js",
                        "~/assets/bundles/knob.bundle.js",
                        "~/assets/bundles/mainscripts.bundle.js",
                        "~/assets/js/pages/index.js",
                        "~/assets/plugins/autosize/autosize.js",
                        "~/assets/plugins/momentjs/moment.js",
                        "~/assets/plugins/dropzone/dropzone.js",
                        "~/assets/bundles/datatablescripts.bundle.js",
                        "~/assets/js/pages/tables/jquery-datatable.js",
                        "~/assets/js/pages/forms/basic-form-elements.js"));

                 bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        
            bundles.Add(new StyleBundle("~/assets/css").Include(
                      "~/assets/plugins/bootstrap/css/bootstrap.min.css",
                    "~/assets/plugins/jvectormap/jquery-jvectormap-2.0.3.min.css",
                    "~/assets/plugins/morrisjs/morris.min.css",
                    "~/assets/css/main.css",
                    "~/assets/plugins/dropzone/dropzone.css",
                    "~/assets/plugins/jquery-datatable/dataTables.bootstrap4.min.css",
                    "~/assets/plugins/bootstrap-material-datetimepicker/css/bootstrap-material-datetimepicker.css",
                    "~/assets/plugins/bootstrap-select/css/bootstrap-select.css",
                    "~/assets/css/color_skins.css" ));

            
        }
    }
}
