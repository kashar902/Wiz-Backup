namespace App.Wiz.Common.Messages;

public static class Constants
{
    public static readonly string Supplier = "$Supplier";
    public static readonly Guid SupplierKey = Guid.Parse("1c4e25bf-63c2-41dc-8908-fd825703d99c");// Guid.NewGuid();
    public static readonly string Customer = "$Customer";
    public static readonly Guid CustomerKey = Guid.Parse("bc35a2a1-5245-4eb8-afe7-67de74962ad7");
    public static readonly string NotFound = "No Record Found";
    public static readonly string LoadDataSuccess = "Data loaded successfully.";
    public static readonly string NotExist = "No Record Exist";
    public static readonly string Error = "Something Went Wrong";
    public static readonly string IsNullValue = "Value Cannot Be Null";
    public static readonly string DeleteSuccessful = "Record Deleted Successfully!";
    public static readonly string UpdateSuccessful = "Record Updated Successfully!";
    public static readonly string AddSuccessful = "Record Added Successfully!";
    public static readonly string UpdateUnsuccessful = "Record Not Updated!";
    public static readonly string DeleteUnsuccessful = "Record Not Deleted!";
    public static readonly string AddUnsuccessful = "Record Not Added!";
    public static readonly string ActivateSuccessful = "Activated Successfully!";
    public static readonly string AlreadyActivate = "Already Activated!";
    public static readonly string AlreadyExist = "This record is already exist!";
    public static readonly string CanNotDeleteParent = "This record has bind with another form record!";
    public static class ResponseMessages
    {
        public const string SomethingWentWrong = "Something went wrong";
        public const string RequestSuccess = "Request Successful";
        public const string RequestFailed = "Request Failed";
    }
    public static class License
    {
        public static readonly string Licensenotexist = "Licensenotexist";
        public static readonly string LicenseExpired = "licenseexpired";
        public static readonly string LicenseVerified = "licenseverified";
        public static readonly string UserLicenseDeleted = "user license deleted successfully";
    }

    public static class AssignResoursesToGroupMessage
    {
        public static readonly string ResourcesAssigned = "All resources are assigned to respective group";
    }

    public static class LoginMessage
    {
        public static readonly string InvalidCredentials = "invalid credentials";
        public static readonly string NoUserFound = "No such user found";
        public static readonly string UserDeleted = "User deleted successfully";
        public static readonly string UserUpdated = "User updated successfully";
        public static readonly string GeneralInfoAdded = "General info added successfully";
        public static readonly string StatusChange = "Status change successfully";
        public static readonly string BranchCompanyPairsException = "BranchCompanyPairs cannot be null or empty.";
    }

}
