﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wsTRH.cuEntrega {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:microsoft-dynamics-schemas/codeunit/AlmacenRepuestos", ConfigurationName="cuEntrega.AlmacenRepuestos_Port")]
    public interface AlmacenRepuestos_Port {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de contenedor (RegistrarEntrega_Result) del mensaje RegistrarEntrega_Result no coincide con el valor predeterminado (RegistrarEntrega)
        [System.ServiceModel.OperationContractAttribute(Action="urn:microsoft-dynamics-schemas/codeunit/AlmacenRepuestos:RegistrarEntrega", ReplyAction="*")]
        wsTRH.cuEntrega.RegistrarEntrega_Result RegistrarEntrega(wsTRH.cuEntrega.RegistrarEntrega request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:microsoft-dynamics-schemas/codeunit/AlmacenRepuestos:RegistrarEntrega", ReplyAction="*")]
        System.Threading.Tasks.Task<wsTRH.cuEntrega.RegistrarEntrega_Result> RegistrarEntregaAsync(wsTRH.cuEntrega.RegistrarEntrega request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RegistrarEntrega", WrapperNamespace="urn:microsoft-dynamics-schemas/codeunit/AlmacenRepuestos", IsWrapped=true)]
    public partial class RegistrarEntrega {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:microsoft-dynamics-schemas/codeunit/AlmacenRepuestos", Order=0)]
        public string codEmpleado;
        
        public RegistrarEntrega() {
        }
        
        public RegistrarEntrega(string codEmpleado) {
            this.codEmpleado = codEmpleado;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RegistrarEntrega_Result", WrapperNamespace="urn:microsoft-dynamics-schemas/codeunit/AlmacenRepuestos", IsWrapped=true)]
    public partial class RegistrarEntrega_Result {
        
        public RegistrarEntrega_Result() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AlmacenRepuestos_PortChannel : wsTRH.cuEntrega.AlmacenRepuestos_Port, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlmacenRepuestos_PortClient : System.ServiceModel.ClientBase<wsTRH.cuEntrega.AlmacenRepuestos_Port>, wsTRH.cuEntrega.AlmacenRepuestos_Port {
        
        public AlmacenRepuestos_PortClient() {
        }
        
        public AlmacenRepuestos_PortClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlmacenRepuestos_PortClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlmacenRepuestos_PortClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlmacenRepuestos_PortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        wsTRH.cuEntrega.RegistrarEntrega_Result wsTRH.cuEntrega.AlmacenRepuestos_Port.RegistrarEntrega(wsTRH.cuEntrega.RegistrarEntrega request) {
            return base.Channel.RegistrarEntrega(request);
        }
        
        public void RegistrarEntrega(string codEmpleado) {
            wsTRH.cuEntrega.RegistrarEntrega inValue = new wsTRH.cuEntrega.RegistrarEntrega();
            inValue.codEmpleado = codEmpleado;
            wsTRH.cuEntrega.RegistrarEntrega_Result retVal = ((wsTRH.cuEntrega.AlmacenRepuestos_Port)(this)).RegistrarEntrega(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<wsTRH.cuEntrega.RegistrarEntrega_Result> wsTRH.cuEntrega.AlmacenRepuestos_Port.RegistrarEntregaAsync(wsTRH.cuEntrega.RegistrarEntrega request) {
            return base.Channel.RegistrarEntregaAsync(request);
        }
        
        public System.Threading.Tasks.Task<wsTRH.cuEntrega.RegistrarEntrega_Result> RegistrarEntregaAsync(string codEmpleado) {
            wsTRH.cuEntrega.RegistrarEntrega inValue = new wsTRH.cuEntrega.RegistrarEntrega();
            inValue.codEmpleado = codEmpleado;
            return ((wsTRH.cuEntrega.AlmacenRepuestos_Port)(this)).RegistrarEntregaAsync(inValue);
        }
    }
}