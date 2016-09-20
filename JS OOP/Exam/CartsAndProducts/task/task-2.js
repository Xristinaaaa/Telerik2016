/* globals module */

"use strict";

function solve() {
    const Validator = {
        validateString(stringToValidate) {
            if (typeof stringToValidate !== 'string') {
                throw new Error(stringToValidate + ' is not a string.');
            }
        },

        validateNumber(stringToValidate) {
            if (typeof stringToValidate !== 'number') {
                throw new Error(stringToValidate + ' is not a number.');
            }
        }
    };

    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = price;
        }

        get productType() {
            return this._productType;
        }
        set productType(productType) {
            Validator.validateString(productType);
            this._productType = productType;
        }

        get name() {
            return this._name;
        }
        set name(name) {
            Validator.validateString(name);
            this._name = name;
        }

        get price() {
            return this._price;
        }
        set price(price) {
            Validator.validateNumber(price);
            this._price = price;
        }
    }

    class ShoppingCart {
        constructor() {
            this.products = [];
        }
        add(product) {
            if (!(product instanceof Product)) {
                throw new Error(product + ' is not a Product type and cannot be added.');
            }

            this.products.push(product);
            return this;
        }

        remove(product) {
            if (!(product instanceof Product)) {
                throw new Error(product + ' is not a Product type and cannot be removed.');
            }
            if (this.products.length === 0) {
                throw new Error('Shopping cart is empty.');
            }
            if (this.products.indexOf(product) < 0) {
                throw new Error('Shopping cart does not contain this product.');
            }

            for (var i = 0, len = this.products.length; i < len; i += 1) {
                if (this.products[i].name === product.name && this.products[i].price === product.price &&
                    this.products[i].productType === product.productType) {
                    return this.products.splice(i, 1);
                }
            }
        }

        showCost() {
            let sumOfCosts = 0;

            if (this.products.length === 0) {
                return 0;
            }

            for (var i = 0, len = this.products.length; i < len; i += 1) {
                sumOfCosts += this.products[i].price;
            }

            return sumOfCosts;
        }

        showProductTypes() {
            let productTypes = {};

            if (this.products.length === 0) {
                return [];
            }
            
            this.products.forEach(item => {
                productTypes[item.productType] = true;
            });

            return Object.keys(productTypes).sort((a, b) => {
                a.toLowerCase();
                b.toLowerCase();

                return a > b;
            });
        }

        getInfo() {
            if (this.products.length === 0) {
                return {
                    totalPrice: 0,
                    products: []
                };
            }

            let nameTypes={};            
            this.products.forEach(item => {
                nameTypes[item.name] = true;
            });

            let uniqueProductsInfo = [];
            let itemToAdd;

			Object.keys(nameTypes).each(function (name) {
                let count=1;
                let tempPrice;
                for(var i=0, len=this.products.length; i<len; i+=1){
                    if(this.products[i].name===name){
                        tempPrice=this.products[i].price;
                        count+=1;
                    }
                }

                itemToAdd = {
                    name: name,
                    totalPrice: tempPrice,
                    quantity: count
                };

                uniqueProductsInfo.push(itemToAdd);
                count=1;
                tempPrice=0;
            });

            let sumOfProducts = this.products.showCost();

            return {
                totalPrice: sumOfProducts,
                products: uniqueProductsInfo
            };
        }
    }

    return {
        Product, ShoppingCart
    };
}

module.exports = solve;