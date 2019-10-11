﻿using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BusinessLogic.Objects;
using StoreApp.DataLibrary.Entities;

namespace StoreApp.DataLibrary.Handlers
{
    public class ParseHandler
    {
        public StoreApp.BusinessLogic.Objects.Customer ContextCustomerToLogicCustomer(StoreApp.DataLibrary.Entities.Customer CTXCustomer)
        {
            StoreApp.BusinessLogic.Objects.Customer BLCustomer = new BusinessLogic.Objects.Customer();

            BLCustomer.customerAddress.street = CTXCustomer.Street;
            BLCustomer.customerAddress.city = CTXCustomer.City;
            BLCustomer.customerAddress.state = CTXCustomer.State;
            BLCustomer.customerAddress.zip = CTXCustomer.Zip;

            BLCustomer.customerID = CTXCustomer.CustomerId;
            BLCustomer.firstName = CTXCustomer.FirstName;
            BLCustomer.lastName = CTXCustomer.LastName;
            

            return BLCustomer;
        }

        public BusinessLogic.Objects.Manager ContextManagerToLogicManager(Entities.Manager CTXman)
        {
            StoreApp.BusinessLogic.Objects.Manager BLMan = new BusinessLogic.Objects.Manager();

            BLMan.managerID = CTXman.ManagerId;
            BLMan.firstName = CTXman.FirstName;
            BLMan.lastName = CTXman.LastName;

            return BLMan;
        }

        public BusinessLogic.Objects.Store ContextStoreToLogicStore(Entities.Store CTXStore)
        {
            StoreApp.BusinessLogic.Objects.Store BLStore = new BusinessLogic.Objects.Store();

            BLStore.address.street = CTXStore.Street;
            BLStore.address.city = CTXStore.City;
            BLStore.address.state = CTXStore.State;
            BLStore.address.zip = CTXStore.Zip;

            BLStore.storeInventory.productData.burgerAmount = CTXStore.BurgerAmount;
            BLStore.storeInventory.productData.friesAmount = CTXStore.FriesAmount;
            BLStore.storeInventory.productData.sodaAmount = CTXStore.SodaAmount;

            BLStore.storeNumber = CTXStore.StoreNumber;

            return BLStore;
        }
        public Entities.Orders LogicOrderToContextOrder(StoreApp.BusinessLogic.Objects.Order BLorder)
        {
            Orders CTXorder = new Orders();

            CTXorder.BurgerAmount = BLorder.customerProductList.burgerAmount;
            CTXorder.FriesAmount = BLorder.customerProductList.friesAmount;
            CTXorder.SodaAmount = BLorder.customerProductList.sodaAmount;

            CTXorder.StoreNumber = BLorder.storeLocation.storeNumber;
            CTXorder.CustomerId = BLorder.customer.customerID;


            return CTXorder;
        }
    }
}