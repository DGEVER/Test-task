using Microsoft.AspNetCore.Mvc;
using Test_task.Models;
using Test_task.Models.CustomModels;

namespace Test_task.Controllers
{
    public class AvailableAllUserController : Controller
    {
        TestTaskContext db;

        public AvailableAllUserController (TestTaskContext db)
        {
            this.db = db;
        }



        [HttpGet]
        public IActionResult FilterFromEntity([FromQuery]Filter filter)
        {
            var queryPaintworkMaterial = db.PaintworkMaterials.AsQueryable();

            if (filter.Name_material != null)
                queryPaintworkMaterial = queryPaintworkMaterial.Where(i => i.NameMaterial == filter.Name_material);

            if (filter.Weight_with_material != null)
                queryPaintworkMaterial = queryPaintworkMaterial.Where(i => i.WeightWithMaterial == filter.Weight_with_material);

            if (filter.Container_volume != null)
                queryPaintworkMaterial = queryPaintworkMaterial.Where(i => i.ContainerVolume == filter.Container_volume);

            if (filter.Brand != null)
                queryPaintworkMaterial = queryPaintworkMaterial.Where(i => i.Brand == filter.Brand);

            if (filter.Item_number != null)
                queryPaintworkMaterial = queryPaintworkMaterial.Where(i => i.ItemNumber == filter.Item_number);

            if (filter.Specific_weight != null)
                queryPaintworkMaterial = queryPaintworkMaterial.Where(i => i.SpecificWeight == filter.Specific_weight);

            if (queryPaintworkMaterial.Count() > 0)
            {
                return Json(queryPaintworkMaterial);
            }

            return new BadRequestResult();
        }
    }
}
