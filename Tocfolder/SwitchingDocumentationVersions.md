 
 
|   __Compliance, Status, Standards__|   |
|:---|:---| 
|   HTTP DOwnload All Resource|   Downloads all resources referred to be an HTML document (images, scripts, etc.) and validates that they are all available. Applicable to any property containing HTML. |
|   Invalid HTTP Status Codes|   Checks that the target TestStep received an HTTP result with a status code not in the list of defined codes. Applicable to any TestStep that receives HTTP messages. |
|   Not SOAP Fault|   Validates that the last received message is not a SOAP Fault. Applicable to SOAP TestSteps. |
|   Schema Compliance|   Validates that the last received message is compliant with the associated WSDL or WADL schema definition. Applicable to SOAP and REST Test Steps. The schema definition URL supports Property Expansions (e.g. ${#System#my.wsdl.endpoint}/services/PortType? wsdl). |

 
