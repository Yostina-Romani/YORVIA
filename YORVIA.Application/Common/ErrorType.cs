

namespace YORVIA.Application.Common
{
    public enum ErrorType
    {

        None = 0,

        Validation,        
        BadRequest,      
        Unauthorized,  
        Forbidden,        
        NotFound,          
        Conflict,         
        Gone,              
        PreconditionFailed,
        UnprocessableEntity, 
        TooManyRequests,
        Failure
    }
}
