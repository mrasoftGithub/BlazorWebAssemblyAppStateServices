using System;
using Microsoft.AspNetCore.Components;

namespace BlazorBlogProject.Client.Inlichtingen
{
    public class Inlichtingendienst
    {
        public string InlichtingenLand { get; private set; }

        public string InlichtingenProduct { get; private set; }

        public bool DesInformatie { get; private set; }

        // A1. Vergaren door te spelen inlichtingen
        public void VergaarInlichtingen(ComponentBase Bron, string InlichtingenLand, string InlichtingenProduct)
        {
            // Verzamel de gegevens
            this.InlichtingenLand = InlichtingenLand;
            this.InlichtingenProduct = InlichtingenProduct;

            // Aangeven dat de inlichtingen zijn vergaard en verstuurd kunnen worden naar de Inlichtingendienst
            InlichtingenSamengesteld(Bron, InlichtingenLand, InlichtingenProduct);
        }

        // A2. Signaal naar de Inlichtingendienst zodat die weet dat de inlichtingenofficier gegevens heeft gestuurd
        private void InlichtingenSamengesteld(ComponentBase Bron, string InlichtingenLand, string InlichtingenProduct)
            => InlichtingenVerstuurd?.Invoke(Bron, InlichtingenLand, InlichtingenProduct);

        // A3. Signaal dat gedetecteerd wordt door de Inlichtingendienst, inlichtingen van de inlichtingenofficier
        public event Action<ComponentBase, string, string> InlichtingenVerstuurd;

        // B1. Samenstellen Desinformatie
        public void MaakDesInformatie(ComponentBase Bron, string InlichtingenLand, string InlichtingenProduct, bool DesInformatie)
        {
            // De te versturen desinformatie 
            this.InlichtingenLand = InlichtingenLand;
            this.InlichtingenProduct = InlichtingenProduct;
            this.DesInformatie = DesInformatie;

            // Aangeven dat de desinformate is samengesteld en verstuurd kan worden naar de inlichtingenofficier
            DesInformatieSamengesteld(Bron, InlichtingenLand, InlichtingenProduct, DesInformatie);
        }

        // B2. Signaal naar de Inlichtingenofficier zodat die weet dat de Inlichtingendienst desinformatie heeft gestuurd
        private void DesInformatieSamengesteld(ComponentBase Bron, string InlichtingenLand, string InlichtingenProduct, bool DesInformatie)
            => DesInformatieVerstuurd?.Invoke(Bron, InlichtingenLand, InlichtingenProduct, DesInformatie);

        // B3. Signaal dat gedetecteerd wordt door de Inlichtingenofficier, desinformatie van de Inlichtingendienst
        public event Action<ComponentBase, string, string, bool> DesInformatieVerstuurd;

    }
}
