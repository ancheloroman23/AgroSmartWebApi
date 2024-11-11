using AgroSmart.Core.Domain.Entities;
using AgroSmart.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace AgroSmart.Infraestructure.Persistence.Seeds
{
    public static class DefaultCategories
    {
        public static async Task SeedAsync(ApplicationContext context)
        {

            if (!await context.Set<Category>().AnyAsync())
            {
                context.Set<Category>().AddRange(
              new Category { Name = "Produccion Agricola", Description = "Cultivos\r\nMétodos de siembra\r\nNutrición de plantas\r\nControl de plagas y enfermedades\r\n" },
              new Category { Name = "Tecnologia y Automatizacion", Description = "Agricultura de precisión\r\nUso de drones y sensores\r\nSistemas de riego automatizados\r\nMáquinas y equipos agrícolas\r\n" },
              new Category { Name = "Sostenibilidad y Medio Ambiente", Description = "Agricultura orgánica\r\nConservación del suelo y el agua\r\nBiodiversidad y ecosistemas\r\nPrácticas sostenibles\r\n" },
              new Category { Name = "Gestión de Recursos Naturales", Description = "Manejo de agua y riego\r\nFertilización y uso de nutrientes\r\nGestión de residuos y reciclaje\r\n" },
              new Category { Name = "Investigación y Desarrollo (I+D)", Description = "Innovación en cultivos\r\nMejoramiento genético\r\nTecnologías emergentes en agricultura\r\n" },
              new Category { Name = "Economía y Comercialización", Description = "Cadenas de suministro y logística\r\nMercados agrícolas\r\nComercio de productos agrícolas\r\nFinanzas y microcréditos en agricultura\r\n" },
              new Category { Name = "Educación y Capacitación", Description = "Programas de capacitación para agricultores\r\nGuías de buenas prácticas\r\nTalleres y cursos agrícolas\r\n" },
              new Category { Name = "Agricultura Urbana y Vertical", Description = "Jardines urbanos y huertos comunitarios\r\nAgricultura en espacios reducidos\r\nCultivo vertical e hidropónico\r\n" },
              new Category { Name = "Clima y Agricultura Resiliente", Description = "Adaptación al cambio climático\r\nPrácticas para la resiliencia agrícola\r\nPrevención de desastres naturales en la agricultura\r\n" },
              new Category { Name = "Digitalización en la Agricultura", Description = "Uso de software agrícola\r\nAnálisis de datos y Big Data\r\nApps para agricultores\r\n" }
              );

                await context.SaveChangesAsync();
            }

        }
    }
}