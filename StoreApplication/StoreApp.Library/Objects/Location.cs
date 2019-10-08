﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication
{
    public class Location
    {
        public Address address { get; set; }
        public Inventory storeInventory { get; set; }
        public string storeNumber { get; set; }
        public bool CheckInventory(Location locationBeingChecked, Order order)
        {
            //If the ordered amount doesnt exceed any of the three things the store has
            if (locationBeingChecked.storeInventory.productData.burgerAmount >= order.customerProductList.burgerAmount && 
                locationBeingChecked.storeInventory.productData.friesAmount >= order.customerProductList.friesAmount &&
                locationBeingChecked.storeInventory.productData.sodaAmount >= order.customerProductList.sodaAmount)
            {
                //Order is successful
                Console.WriteLine("Location has sufficient product.");

                UpdateInventory(locationBeingChecked, order);

                return true;
            }
            else
            {

                Console.WriteLine("Location does not have all the necessary things needed for the order. Location contains " +
                    locationBeingChecked.storeInventory.productData.burgerAmount.ToString() + " burgers, " + 
                    locationBeingChecked.storeInventory.productData.friesAmount.ToString() +  " fries, and " +
                    locationBeingChecked.storeInventory.productData.sodaAmount.ToString());

                Console.WriteLine("Client order is requesting " +
                    order.customerProductList.burgerAmount + " burgers, " +
                    order.customerProductList.friesAmount.ToString() + " fries, and " +
                    order.customerProductList.sodaAmount.ToString());

                return false;
            }
        }
        public void UpdateInventory(Location locationToBeUpdated, Order placedOrder)
        {
            locationToBeUpdated.storeInventory.productData.burgerAmount = locationToBeUpdated.storeInventory.productData.burgerAmount - placedOrder.customerProductList.burgerAmount;
            locationToBeUpdated.storeInventory.productData.friesAmount = locationToBeUpdated.storeInventory.productData.friesAmount - placedOrder.customerProductList.friesAmount;
            locationToBeUpdated.storeInventory.productData.sodaAmount = locationToBeUpdated.storeInventory.productData.sodaAmount - placedOrder.customerProductList.sodaAmount;

            Console.WriteLine("Updated location for store number " + locationToBeUpdated.storeNumber.ToString() + ".\n");
            Console.WriteLine("Store inventory contains " +
                    locationToBeUpdated.storeInventory.productData.burgerAmount.ToString() + " burgers, " +
                    locationToBeUpdated.storeInventory.productData.friesAmount.ToString() + " fries, and " +
                    locationToBeUpdated.storeInventory.productData.sodaAmount.ToString());

            return;
        }
        public bool CheckLocationNotNull()
        {
            if (this.storeInventory.CheckInventoryNotNull() == true && this.storeNumber != null && this.address.CheckAddressNotNull() == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}