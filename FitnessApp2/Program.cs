using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceProvider = CreateServiceProvider();

            var yoneticiService = serviceProvider.GetService<IYoneticiService>();
            var personelService = serviceProvider.GetService<IPersonelService>();

            var girisForm = new YoneticiGirisiYap(yoneticiService, personelService, serviceProvider);
            Application.Run(girisForm);
        }
        static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<IPaketDal, EfPaketDal>();
            services.AddScoped<IPersonelDal, EfPersonelDal>();
            services.AddScoped<IYoneticiGirisiDal, EfYoneticiGirisi>();
            services.AddScoped<IPersonelGirisiDal, EfPersonelGirisi>();
            services.AddScoped<IEgitmenDal, EfEgitmenDal>();
            services.AddScoped<IMusteriDal, EfMusteriDal>();  // Eksik baðýmlýlýk
            services.AddScoped<IGiderDal, EfGiderDal>();
            services.AddScoped<IPaketService, PaketManager>();
            services.AddScoped<IPersonellerService, PersonellerManager>();
            services.AddScoped<IYoneticiService, YoneticiManager>();
            services.AddScoped<IPersonelService, PersonelManager>();
            services.AddScoped<IEgitmenService, EgitmenManager>();
            services.AddScoped<IGiderService, GiderManager>();
            services.AddScoped<IMusteriService, MusteriManager>();

            services.AddSingleton<YoneticiPaneli>();
            services.AddSingleton<YoneticiGirisiYap>();
            services.AddSingleton<PersonelPaneli>();
            services.AddSingleton<Muhasebe>();
            return services.BuildServiceProvider();
        }
       
    }
}