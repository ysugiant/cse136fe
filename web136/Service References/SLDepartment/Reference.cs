﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web136.SLDepartment {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Department", Namespace="http://schemas.datacontract.org/2004/07/POCO")]
    [System.SerializableAttribute()]
    public partial class Department : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int chairIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string deptNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int chairID {
            get {
                return this.chairIDField;
            }
            set {
                if ((this.chairIDField.Equals(value) != true)) {
                    this.chairIDField = value;
                    this.RaisePropertyChanged("chairID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string deptName {
            get {
                return this.deptNameField;
            }
            set {
                if ((object.ReferenceEquals(this.deptNameField, value) != true)) {
                    this.deptNameField = value;
                    this.RaisePropertyChanged("deptName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SLDepartment.ISLDepartment")]
    public interface ISLDepartment {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/GetDepartmentDetail", ReplyAction="http://tempuri.org/ISLDepartment/GetDepartmentDetailResponse")]
        web136.SLDepartment.GetDepartmentDetailResponse GetDepartmentDetail(web136.SLDepartment.GetDepartmentDetailRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/GetDepartmentDetail", ReplyAction="http://tempuri.org/ISLDepartment/GetDepartmentDetailResponse")]
        System.Threading.Tasks.Task<web136.SLDepartment.GetDepartmentDetailResponse> GetDepartmentDetailAsync(web136.SLDepartment.GetDepartmentDetailRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/GetDepartmentList", ReplyAction="http://tempuri.org/ISLDepartment/GetDepartmentListResponse")]
        web136.SLDepartment.GetDepartmentListResponse GetDepartmentList(web136.SLDepartment.GetDepartmentListRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/GetDepartmentList", ReplyAction="http://tempuri.org/ISLDepartment/GetDepartmentListResponse")]
        System.Threading.Tasks.Task<web136.SLDepartment.GetDepartmentListResponse> GetDepartmentListAsync(web136.SLDepartment.GetDepartmentListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/InsertDepartment", ReplyAction="http://tempuri.org/ISLDepartment/InsertDepartmentResponse")]
        web136.SLDepartment.InsertDepartmentResponse InsertDepartment(web136.SLDepartment.InsertDepartmentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/InsertDepartment", ReplyAction="http://tempuri.org/ISLDepartment/InsertDepartmentResponse")]
        System.Threading.Tasks.Task<web136.SLDepartment.InsertDepartmentResponse> InsertDepartmentAsync(web136.SLDepartment.InsertDepartmentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/DeleteDepartment", ReplyAction="http://tempuri.org/ISLDepartment/DeleteDepartmentResponse")]
        web136.SLDepartment.DeleteDepartmentResponse DeleteDepartment(web136.SLDepartment.DeleteDepartmentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/DeleteDepartment", ReplyAction="http://tempuri.org/ISLDepartment/DeleteDepartmentResponse")]
        System.Threading.Tasks.Task<web136.SLDepartment.DeleteDepartmentResponse> DeleteDepartmentAsync(web136.SLDepartment.DeleteDepartmentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/UpdateDepartment", ReplyAction="http://tempuri.org/ISLDepartment/UpdateDepartmentResponse")]
        web136.SLDepartment.UpdateDepartmentResponse UpdateDepartment(web136.SLDepartment.UpdateDepartmentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLDepartment/UpdateDepartment", ReplyAction="http://tempuri.org/ISLDepartment/UpdateDepartmentResponse")]
        System.Threading.Tasks.Task<web136.SLDepartment.UpdateDepartmentResponse> UpdateDepartmentAsync(web136.SLDepartment.UpdateDepartmentRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDepartmentDetail", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDepartmentDetailRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string[] errors;
        
        public GetDepartmentDetailRequest() {
        }
        
        public GetDepartmentDetailRequest(string name, string[] errors) {
            this.name = name;
            this.errors = errors;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDepartmentDetailResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDepartmentDetailResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public web136.SLDepartment.Department GetDepartmentDetailResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string[] errors;
        
        public GetDepartmentDetailResponse() {
        }
        
        public GetDepartmentDetailResponse(web136.SLDepartment.Department GetDepartmentDetailResult, string[] errors) {
            this.GetDepartmentDetailResult = GetDepartmentDetailResult;
            this.errors = errors;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDepartmentList", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDepartmentListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string[] errors;
        
        public GetDepartmentListRequest() {
        }
        
        public GetDepartmentListRequest(string[] errors) {
            this.errors = errors;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDepartmentListResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDepartmentListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public web136.SLDepartment.Department[] GetDepartmentListResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string[] errors;
        
        public GetDepartmentListResponse() {
        }
        
        public GetDepartmentListResponse(web136.SLDepartment.Department[] GetDepartmentListResult, string[] errors) {
            this.GetDepartmentListResult = GetDepartmentListResult;
            this.errors = errors;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertDepartment", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InsertDepartmentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public web136.SLDepartment.Department dept;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string[] errors;
        
        public InsertDepartmentRequest() {
        }
        
        public InsertDepartmentRequest(web136.SLDepartment.Department dept, string[] errors) {
            this.dept = dept;
            this.errors = errors;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertDepartmentResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InsertDepartmentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string[] errors;
        
        public InsertDepartmentResponse() {
        }
        
        public InsertDepartmentResponse(string[] errors) {
            this.errors = errors;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteDepartment", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DeleteDepartmentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string[] errors;
        
        public DeleteDepartmentRequest() {
        }
        
        public DeleteDepartmentRequest(string name, string[] errors) {
            this.name = name;
            this.errors = errors;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteDepartmentResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DeleteDepartmentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string[] errors;
        
        public DeleteDepartmentResponse() {
        }
        
        public DeleteDepartmentResponse(string[] errors) {
            this.errors = errors;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UpdateDepartment", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UpdateDepartmentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public web136.SLDepartment.Department dept;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string[] errors;
        
        public UpdateDepartmentRequest() {
        }
        
        public UpdateDepartmentRequest(web136.SLDepartment.Department dept, string[] errors) {
            this.dept = dept;
            this.errors = errors;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UpdateDepartmentResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UpdateDepartmentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string[] errors;
        
        public UpdateDepartmentResponse() {
        }
        
        public UpdateDepartmentResponse(string[] errors) {
            this.errors = errors;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISLDepartmentChannel : web136.SLDepartment.ISLDepartment, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SLDepartmentClient : System.ServiceModel.ClientBase<web136.SLDepartment.ISLDepartment>, web136.SLDepartment.ISLDepartment {
        
        public SLDepartmentClient() {
        }
        
        public SLDepartmentClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SLDepartmentClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SLDepartmentClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SLDepartmentClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        web136.SLDepartment.GetDepartmentDetailResponse web136.SLDepartment.ISLDepartment.GetDepartmentDetail(web136.SLDepartment.GetDepartmentDetailRequest request) {
            return base.Channel.GetDepartmentDetail(request);
        }
        
        public web136.SLDepartment.Department GetDepartmentDetail(string name, ref string[] errors) {
            web136.SLDepartment.GetDepartmentDetailRequest inValue = new web136.SLDepartment.GetDepartmentDetailRequest();
            inValue.name = name;
            inValue.errors = errors;
            web136.SLDepartment.GetDepartmentDetailResponse retVal = ((web136.SLDepartment.ISLDepartment)(this)).GetDepartmentDetail(inValue);
            errors = retVal.errors;
            return retVal.GetDepartmentDetailResult;
        }
        
        public System.Threading.Tasks.Task<web136.SLDepartment.GetDepartmentDetailResponse> GetDepartmentDetailAsync(web136.SLDepartment.GetDepartmentDetailRequest request) {
            return base.Channel.GetDepartmentDetailAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        web136.SLDepartment.GetDepartmentListResponse web136.SLDepartment.ISLDepartment.GetDepartmentList(web136.SLDepartment.GetDepartmentListRequest request) {
            return base.Channel.GetDepartmentList(request);
        }
        
        public web136.SLDepartment.Department[] GetDepartmentList(ref string[] errors) {
            web136.SLDepartment.GetDepartmentListRequest inValue = new web136.SLDepartment.GetDepartmentListRequest();
            inValue.errors = errors;
            web136.SLDepartment.GetDepartmentListResponse retVal = ((web136.SLDepartment.ISLDepartment)(this)).GetDepartmentList(inValue);
            errors = retVal.errors;
            return retVal.GetDepartmentListResult;
        }
        
        public System.Threading.Tasks.Task<web136.SLDepartment.GetDepartmentListResponse> GetDepartmentListAsync(web136.SLDepartment.GetDepartmentListRequest request) {
            return base.Channel.GetDepartmentListAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        web136.SLDepartment.InsertDepartmentResponse web136.SLDepartment.ISLDepartment.InsertDepartment(web136.SLDepartment.InsertDepartmentRequest request) {
            return base.Channel.InsertDepartment(request);
        }
        
        public void InsertDepartment(web136.SLDepartment.Department dept, ref string[] errors) {
            web136.SLDepartment.InsertDepartmentRequest inValue = new web136.SLDepartment.InsertDepartmentRequest();
            inValue.dept = dept;
            inValue.errors = errors;
            web136.SLDepartment.InsertDepartmentResponse retVal = ((web136.SLDepartment.ISLDepartment)(this)).InsertDepartment(inValue);
            errors = retVal.errors;
        }
        
        public System.Threading.Tasks.Task<web136.SLDepartment.InsertDepartmentResponse> InsertDepartmentAsync(web136.SLDepartment.InsertDepartmentRequest request) {
            return base.Channel.InsertDepartmentAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        web136.SLDepartment.DeleteDepartmentResponse web136.SLDepartment.ISLDepartment.DeleteDepartment(web136.SLDepartment.DeleteDepartmentRequest request) {
            return base.Channel.DeleteDepartment(request);
        }
        
        public void DeleteDepartment(string name, ref string[] errors) {
            web136.SLDepartment.DeleteDepartmentRequest inValue = new web136.SLDepartment.DeleteDepartmentRequest();
            inValue.name = name;
            inValue.errors = errors;
            web136.SLDepartment.DeleteDepartmentResponse retVal = ((web136.SLDepartment.ISLDepartment)(this)).DeleteDepartment(inValue);
            errors = retVal.errors;
        }
        
        public System.Threading.Tasks.Task<web136.SLDepartment.DeleteDepartmentResponse> DeleteDepartmentAsync(web136.SLDepartment.DeleteDepartmentRequest request) {
            return base.Channel.DeleteDepartmentAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        web136.SLDepartment.UpdateDepartmentResponse web136.SLDepartment.ISLDepartment.UpdateDepartment(web136.SLDepartment.UpdateDepartmentRequest request) {
            return base.Channel.UpdateDepartment(request);
        }
        
        public void UpdateDepartment(web136.SLDepartment.Department dept, ref string[] errors) {
            web136.SLDepartment.UpdateDepartmentRequest inValue = new web136.SLDepartment.UpdateDepartmentRequest();
            inValue.dept = dept;
            inValue.errors = errors;
            web136.SLDepartment.UpdateDepartmentResponse retVal = ((web136.SLDepartment.ISLDepartment)(this)).UpdateDepartment(inValue);
            errors = retVal.errors;
        }
        
        public System.Threading.Tasks.Task<web136.SLDepartment.UpdateDepartmentResponse> UpdateDepartmentAsync(web136.SLDepartment.UpdateDepartmentRequest request) {
            return base.Channel.UpdateDepartmentAsync(request);
        }
    }
}