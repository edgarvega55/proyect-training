using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_de_entrenamiento.Repositorios;

namespace UnitTest.Repositorios
{
    [TestClass]
    public class WidgetRepositories
    {
        [TestMethod]
        public void savingAWidget_whenHavaAllData_returnAObjectWidget()
        {
            int WidgetID = 1;
            int ContainerID = 1;
            string Locked = "Y";
            string Properties = "{}";
            int SortOrder = 1;
            string P2PWidgetTypeID = "Donation";
            bool IsRequired = true;
            string IsVisible = "y";
            string VisibilityConditionTypeID = "y";

            var Repository = new WidgetRepository();
            //Act
            var result = Repository.AddWidget(WidgetID, ContainerID, Locked, Properties, SortOrder, P2PWidgetTypeID, IsRequired, IsVisible, VisibilityConditionTypeID);
            
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void savingAWidgetContent_returnAListObjectsWidgetContent()
        {
            int WidgetID = 1;

            var Repository = new WidgetRepository();
            //Act
            var result = Repository.AddWidgetContent(WidgetID);

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
