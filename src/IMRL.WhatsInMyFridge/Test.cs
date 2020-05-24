using System;
using System.Collections.Generic;
using System.Text;
using IMRL.WhatsInMyFridge.Core.Recipes.Base;
using IMRL.WhatsInMyFridge.DataAccess;
using IMRL.WhatsInMyFridge.DataAccess.Repositories;

namespace IMRL.WhatsInMyFridge
{
    class Test
    {
        private readonly IDataRepository dataRepository;
        private readonly IUnitOfWork unitOfWork;

        public Test(IDataRepository dataRepository, IUnitOfWork unitOfWork)
        {
            this.dataRepository = dataRepository;
            this.unitOfWork = unitOfWork;
        }
        public void show() {
            var recipeExample = new Recipe(Guid.NewGuid(), "normal", "prajitura", "approved", "https://github.com/RePierre/tap2020-demo/blob/master/src/Tap2020Demo/Examples/DependencyInjectionExample.cs");
            dataRepository.Insert(recipeExample);
            unitOfWork.Commit();
            Console.WriteLine("hello");
        }
    }
}
