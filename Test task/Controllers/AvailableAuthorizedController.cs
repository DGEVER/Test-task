using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using Test_task.Models;
using Test_task.Models.CustomModels;

namespace Test_task.Controllers
{
    public class AvailableAuthorizedController : Controller
    {
        TestTaskContext db;

        public AvailableAuthorizedController(TestTaskContext db) 
        {
        this.db = db;
        }

       
        [HttpGet]
        public IActionResult Read(string id)
        {
            if (id != null)
            {
                var resultSearch = db.PaintworkMaterials.FirstOrDefault(g => g.Id.ToString() == id);
                if (resultSearch != null)
                    return Json(resultSearch);
            } else
            {
                var resultSearch = db.PaintworkMaterials.ToList();
                if (resultSearch != null) 
                    return Json(resultSearch);
            }
            
            return new NotFoundResult();
        }

        [HttpPost]
        public IActionResult Create()
        {
            var request = HttpContext.Request;

            try
            {
                var dataRequest = request.ReadFromJsonAsync<PaintworkMaterialCustom>();

                if (dataRequest.Result != null)
                {
                    var insertData = new PaintworkMaterial
                    {
                        NameMaterial = dataRequest.Result.Name_material,
                        ItemNumber = dataRequest.Result.Item_number,
                        TypeMaterial = dataRequest.Result.Type_material,
                        SpecificWeight = dataRequest.Result.Specific_weight,
                        ContainerVolume = dataRequest.Result.Container_volume,
                        WeightWithMaterial = dataRequest.Result.Weight_with_material,
                        Brand = dataRequest.Result.Brand
                    };

                    db.PaintworkMaterials.Add(insertData);
                    db.SaveChanges();
                    return new OkResult();
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

            return new BadRequestResult();
        }

        [HttpPut]
        public IActionResult Update()
        {
            var request = HttpContext.Request;

            try
            {
                var dataRequest = request.ReadFromJsonAsync<PaintworkMaterialCustom>();

                if (dataRequest.Result != null)
                {
                    var insertData = new PaintworkMaterial
                    {
                        NameMaterial = dataRequest.Result.Name_material,
                        ItemNumber = dataRequest.Result.Item_number,
                        TypeMaterial = dataRequest.Result.Type_material,
                        SpecificWeight = dataRequest.Result.Specific_weight,
                        ContainerVolume = dataRequest.Result.Container_volume,
                        WeightWithMaterial = dataRequest.Result.Weight_with_material,
                        Brand = dataRequest.Result.Brand,
                        Id = new Guid(dataRequest.Result.Id)
                    };

                    db.PaintworkMaterials.Update(insertData);
                    db.SaveChanges();
                    return new OkResult();
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

            return new BadRequestResult();
        }


        [HttpDelete] 
        public IActionResult Delete(string id) 
        { 
            if (id != null)
            {
                var findData = db.PaintworkMaterials.FirstOrDefault(i => i.Id.ToString() == id);

                if (findData != null)
                {
                    db.Remove(findData);
                    db.SaveChanges();
                    return new OkResult();
                }
            }

            return new BadRequestResult();
        }



    }
}
