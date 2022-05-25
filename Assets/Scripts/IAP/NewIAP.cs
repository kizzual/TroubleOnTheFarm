using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace UnityEngine.Purchasing
{
    public class NewIAP : MonoBehaviour, IStoreListener
    {

        private static IStoreController m_StoreController;
        private static IExtensionProvider m_StoreExtensionProvider;


        public const string Coins250 = "250_coins";
        public const string Coins1000 = "1000_coins";

        public const string NoADS = "";

        public Container container;
        public Game_controller _gameController;

        /* public const string pMoney80 = "250_coins";
         public const string pNoAds = "no_ads";

         public const string pMoney80AppStore = "1000_coins";*/
        /* public const string pNoAdsAppStore = "app_no_ads";

         public const string pMoney80GooglePlay = "gp_money_80";
         public const string pNoAdsGooglePlay = "no_ads";*/

        void Awake()
        {
            if (m_StoreController == null)
            {
                InitializePurchasing();
            }
        }

        public void InitializePurchasing()
        {
            if (IsInitialized())
            {
                return;
            }

            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            builder.AddProduct(Coins250, ProductType.Consumable);
            builder.AddProduct(Coins1000, ProductType.Consumable);
            builder.AddProduct(NoADS, ProductType.NonConsumable);

            UnityPurchasing.Initialize(this, builder);
        }

        private bool IsInitialized()
        {
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }

        public void BuyProductID(string productId)
        {
            try
            {
                if (IsInitialized())
                {
                    Product product = m_StoreController.products.WithID(productId);

                    if (product != null && product.availableToPurchase)
                    {
                        Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
                        m_StoreController.InitiatePurchase(product);
                    }
                    else
                    {
                        Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                    }
                }
                else
                {
                    Debug.Log("BuyProductID FAIL. Not initialized.");
                }
            }
            catch (Exception e)
            {
                Debug.Log("BuyProductID: FAIL. Exception during purchase. " + e);
            }
        }

        public void RestorePurchases()
        {
            if (!IsInitialized())
            {
                Debug.Log("RestorePurchases FAIL. Not initialized.");
                return;
            }

            if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
            {
                Debug.Log("RestorePurchases started ...");

                var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
                apple.RestoreTransactions((result) =>
                {
                    Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                });
            }
            else
            {
                Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            }
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            Debug.Log("OnInitialized: Completed!");

            m_StoreController = controller;
            m_StoreExtensionProvider = extensions;
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            if (String.Equals(args.purchasedProduct.definition.id, Coins250, StringComparison.Ordinal))
            {
                //Action for no ads
                BuyCoins250();
            }
            if (String.Equals(args.purchasedProduct.definition.id, Coins1000, StringComparison.Ordinal))
            {
                BuyCoins1000();
            }
            if (String.Equals(args.purchasedProduct.definition.id, NoADS, StringComparison.Ordinal))
            {
                BuyNoADS();
            }



            Debug.Log($"Purchase Succesful");

            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }
        private void BuyCoins250()
        {
            _gameController.GoldForSellRessources(250);
            container._soundController.BuySometing();
            Debug.Log("Buy 250 gold");
        }
        private void BuyCoins1000()
        {
            _gameController.GoldForSellRessources(1000);
            container._soundController.BuySometing();

            Debug.Log("Buy 1000 gold");
        }
        private void BuyNoADS()
        {
           
        }
    }
    //  Buy Functions


}
