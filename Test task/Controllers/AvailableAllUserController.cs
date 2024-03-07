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


        //TODO: Переписать все методы на async\await
        [HttpGet]
        public IActionResult FilterFromUrl()
        {   
            var request = HttpContext.Request;

            var query = request.Query;


            var filter = new Filter
            {
                Name_material = query["Name_material"],
                Brand = query["Brand"],
                Item_number = query["Item_number"]
            };



            try
            {
                filter.Weight_with_material = float.Parse(query["Weight_with_material"]);
            }
            catch
            {
                filter.Weight_with_material = null;
            }

            try
            {
                filter.Container_volume = float.Parse(query["Container_volume"]);
            }
            catch
            {
                filter.Container_volume = null;
            }

            try
            {
                filter.Specific_weight = float.Parse(query["Specific_weight"]);
            }
            catch
            {
                filter.Specific_weight = null;
            }

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
