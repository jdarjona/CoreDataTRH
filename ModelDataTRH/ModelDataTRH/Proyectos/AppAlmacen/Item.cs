﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataTRH.Proyectos
{
    class Item
    {
        public bool AENOR { get; set; }
        public bool AENORSpecified { get; set; }
        public string Alias_2 { get; set; }
        public bool Allow_Invoice_Disc { get; set; }
        public bool Allow_Invoice_DiscSpecified { get; set; }
        public bool Allow_Online_Adjustment { get; set; }
        public bool Allow_Online_AdjustmentSpecified { get; set; }
        public decimal Altura_Paquete { get; set; }
        public bool Altura_PaqueteSpecified { get; set; }
        public int Barras_Ahorro_Long { get; set; }
        public bool Barras_Ahorro_LongSpecified { get; set; }
        public int Barras_Ahorro_Trans { get; set; }
        public bool Barras_Ahorro_TransSpecified { get; set; }
        public bool Barras_Dobles { get; set; }
        public bool Barras_DoblesSpecified { get; set; }
        public decimal Base { get; set; }
        public string Base_Unit_of_Measure { get; set; }
        public bool BaseSpecified { get; set; }
        public bool Blocked { get; set; }
        public bool BlockedSpecified { get; set; }
        public decimal Cantidad { get; set; }
        public bool CantidadSpecified { get; set; }
        public bool CARES { get; set; }
        public bool CARESSpecified { get; set; }
        public string Cliente_Etiqueta { get; set; }
        public string Cod_Antiguo { get; set; }
        public string Cod_Barco { get; set; }
        public bool Cost_is_Adjusted { get; set; }
        public bool Cost_is_AdjustedSpecified { get; set; }
        public string  Costing_Method { get; set; }
        public bool Costing_MethodSpecified { get; set; }
        public string Country_Region_Calidad { get; set; }
        public string Description { get; set; }
        public string Description_2 { get; set; }
        public decimal Descuento_Comercial { get; set; }
        public string Designacion { get; set; }
        public decimal Diametro { get; set; }
        public decimal Diámetro_Alambrón { get; set; }
        public bool Diámetro_AlambrónSpecified { get; set; }
        public string Diametro_Grafil { get; set; }
        public decimal Diametro_Long { get; set; }
        public bool Diametro_LongSpecified { get; set; }
        public decimal Diametro_Trans { get; set; }
        public bool Diametro_TransSpecified { get; set; }
        public bool DiametroSpecified { get; set; }
        public bool EHE08 { get; set; }
        public bool EHE08Specified { get; set; }
        public string Envio_Malla_MM_Cliente { get; set; }
        public bool EPI { get; set; }
        public bool EPISpecified { get; set; }
        public bool Especial { get; set; }
        public bool EspecialSpecified { get; set; }
        public bool Estandar { get; set; }
        public bool EstandarSpecified { get; set; }
        public decimal euros_Kg { get; set; }
        public bool euros_KgSpecified { get; set; }
        public decimal euros_m2 { get; set; }
        public bool euros_m2Specified { get; set; }
        public decimal euros_Paño { get; set; }
        public bool euros_PañoSpecified { get; set; }
        public System.DateTime Fecha_Descuento { get; set; }
        public bool Fecha_DescuentoSpecified { get; set; }
        public System.DateTime Fecha_Embarque { get; set; }
        public bool Fecha_EmbarqueSpecified { get; set; }
        public System.DateTime Fecha_Planilla { get; set; }
        public bool Fecha_PlanillaSpecified { get; set; }

        public bool Flushing_MethodSpecified { get; set; }
        public bool Fuera_de_gama { get; set; }
        public bool Fuera_de_gamaSpecified { get; set; }
        public string Gen_Prod_Posting_Group { get; set; }
        public string Global_Dimension_1_Code { get; set; }
        public decimal Gross_Weight { get; set; }
        public bool Gross_WeightSpecified { get; set; }
        public bool Include_Inventory { get; set; }
        public bool Include_InventorySpecified { get; set; }
        public decimal Inventario_Peso { get; set; }
        public bool Inventario_PesoSpecified { get; set; }
        public string Inventory_Posting_Group { get; set; }
        public string Item_Category_Code { get; set; }
        public string Key { get; set; }
        public decimal Kg_M2_Comercial { get; set; }
        public bool Kg_M2_ComercialSpecified { get; set; }
        public decimal Kgs_Paño { get; set; }
        public bool Kgs_PañoSpecified { get; set; }
        public decimal Kgs_Paquete { get; set; }
        public bool Kgs_PaqueteSpecified { get; set; }
        public decimal KGxM2 { get; set; }
        public bool KGxM2Specified { get; set; }
        public System.DateTime Last_Counting_Period_Update { get; set; }
        public bool Last_Counting_Period_UpdateSpecified { get; set; }
        public System.DateTime Last_Date_Modified { get; set; }
        public bool Last_Date_ModifiedSpecified { get; set; }
        public decimal Last_Direct_Cost { get; set; }
        public bool Last_Direct_CostSpecified { get; set; }
        public decimal Long_Barra { get; set; }
        public bool Long_BarraSpecified { get; set; }
        public decimal Long_Rejilla { get; set; }
        public bool Long_RejillaSpecified { get; set; }
        public bool Low_Level_CodeSpecified { get; set; }
        public decimal M_Longitudinal { get; set; }
        public bool M_LongitudinalSpecified { get; set; }
        public decimal M_Transversal { get; set; }
        public bool M_TransversalSpecified { get; set; }
        public decimal m2_Paño { get; set; }
        public bool m2_PañoSpecified { get; set; }
        public decimal m2_Paquete { get; set; }
        public bool m2_PaqueteSpecified { get; set; }
        public bool Malla_Estandar { get; set; }
        public bool Malla_EstandarSpecified { get; set; }

        public bool Manufacturing_PolicySpecified { get; set; }
        public decimal Minimum_Order_Quantity { get; set; }
        public bool Minimum_Order_QuantitySpecified { get; set; }
        public decimal Net_Weight { get; set; }
        public bool Net_WeightSpecified { get; set; }
        public string No { get; set; }
        public decimal Nº_Barras_Dobles { get; set; }
        public bool Nº_Barras_DoblesSpecified { get; set; }
        public decimal Nº_Barras_Long { get; set; }
        public bool Nº_Barras_LongSpecified { get; set; }
        public decimal Nº_Barras_Trans { get; set; }
        public bool Nº_Barras_TransSpecified { get; set; }
        public decimal Nº_Puntadas { get; set; }
        public bool Nº_PuntadasSpecified { get; set; }
        public decimal Nº_Rollo { get; set; }
        public bool Nº_RolloSpecified { get; set; }
        public string No_Series { get; set; }
        public string Nombre_Categoría { get; set; }
        public string Nombre_Grupo { get; set; }
        public string NombreDescripcionGrupoContable { get; set; }
        public decimal Paños_x_Paquete { get; set; }
        public bool Paños_x_PaqueteSpecified { get; set; }
        public int Paquetes_por_Camión { get; set; }
        public bool Paquetes_por_CamiónSpecified { get; set; }
        public bool Permite_stock_negativo { get; set; }
        public bool Permite_stock_negativoSpecified { get; set; }
        public decimal Peso_Medio_Teórico { get; set; }
        public bool Peso_Medio_TeóricoSpecified { get; set; }
        public string Product_Group_Code { get; set; }
        public string Production_BOM_No { get; set; }
        public bool Proveerdor_Unico { get; set; }
        public bool Proveerdor_UnicoSpecified { get; set; }
        public string Purch_Unit_of_Measure { get; set; }
        public string Put_away_Unit_of_Measure_Code { get; set; }

        public bool Reordering_PolicySpecified { get; set; }

        public bool Replenishment_SystemSpecified { get; set; }

        public bool ReserveSpecified { get; set; }
        public decimal Rounding_Precision { get; set; }
        public bool Rounding_PrecisionSpecified { get; set; }
        public string Routing_No { get; set; }
        public string Sales_Unit_of_Measure { get; set; }
        public int Saliente_Long_U1 { get; set; }
        public bool Saliente_Long_U1Specified { get; set; }
        public int Saliente_Long_U2 { get; set; }
        public bool Saliente_Long_U2Specified { get; set; }
        public int Saliente_Trans_U3 { get; set; }
        public bool Saliente_Trans_U3Specified { get; set; }
        public int Saliente_Trans_U4 { get; set; }
        public bool Saliente_Trans_U4Specified { get; set; }
        public string Search_Description { get; set; }
        public int Separacion_BL_Ahorro_PA { get; set; }
        public bool Separacion_BL_Ahorro_PASpecified { get; set; }
        public int Separacion_BT_Ahorro_PA { get; set; }
        public bool Separacion_BT_Ahorro_PASpecified { get; set; }
        public string Subtipo { get; set; }
        public bool SubtipoSpecified { get; set; }
        public decimal Tamaño_Barra_Grafil { get; set; }
        public bool Tamaño_Barra_GrafilSpecified { get; set; }
        public decimal Tamaño_Carrete_Grafil { get; set; }
        public bool Tamaño_Carrete_GrafilSpecified { get; set; }
        public string Tariff_No { get; set; }
        public decimal Trans_Barra { get; set; }
        public bool Trans_BarraSpecified { get; set; }
        public decimal Trans_Rejilla { get; set; }
        public bool Trans_RejillaSpecified { get; set; }
        public bool UNE36092 { get; set; }
        public bool UNE36092Specified { get; set; }
        public string Unidad_Base { get; set; }
        public decimal Unit_Cost { get; set; }
        public bool Unit_CostSpecified { get; set; }
        public string VAT_Prod_Posting_Group { get; set; }
    }
}
