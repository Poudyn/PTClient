# PTClient

## Framework for easier use of Telegram.Td
 - Set Delegate for get updates
 - Filter updates
    - Filter by type
    - Filter by type & linq
 - Get specific value from filtered update with [RefToken](https://github.com/Poudyn/RefToken)
 - Uses methods with a specific type of return that are generated by [PTClient.Generator](https://github.com/Poudyn/PTClient.Generator)
    - The return type is TdResult
 
    
### Filter all updates
```C#
var filterAll = new Filter<Update>(x=>Console.WriteLine(x.GetType()));
````
### Filter special update by linq
```C#
var filterByLinq = new Filter<UpdateAuthorizationState>(OnAuthorizationStateWaitTdlibParameters,
                                                     x => x.AuthorizationState.GetType() == typeof(AuthorizationStateWaitTdlibParameters));
                                                     
void OnAuthorizationStateWaitTdlibParameters(UpdateAuthorizationState state)
{
//do something
}
```
### Get special value from update
```C#
var specialValue = new Filter<UpdateNewMessage, string>(x => Console.WriteLine(x), "Message.Content.Text.Text")
```
- This filter gives you the text of the message

### Get special value from filtered update
```C#
var specialValue = new Filter<UpdateNewMessage, string>(x => Console.WriteLine(x), x=>x.Message.ChatId == 00000000 , "Message.Content.Text.Text")
```
- When a message is received from a chat with the ChatId 00000000, the text of the message will be provided to you

## Create Client
```C#
var filters = new List<IFilter>(//anyfilter):
tdClient = new TdClient(filters);
tdClient.Run();
```
### Send a request without having to receive a response
```C#
TdlibParameters parameters = new()
{
//// parameters
};
tdClient.Send(new SetTdlibParameters(parameters));
```
### Send request and receive result
```C#
TdResult<Ok> tdResult = await  tdClient.SetAuthenticationPhoneNumberAsync(new SetAuthenticationPhoneNumber
{
  PhoneNumber = "+1....."
});
if(tdResult.Successful)
{
  Console.WriteLine(tdResult.Result);
}
else
{
 Console.WriteLine($"Message : {tdResult.Error.Message} Code : {tdResult.Error.Code}");
}
```
### About Me & This project
This was my first project and I tried to write a useful and easy project.
If you have an idea or opinion, be sure to let me know
Also, this project is based on version 1.7 of Telegram.Td, and if you have a higher version of Telegram.Td, share it with me to update the project.
An example project will be available soon

Contact with me : [Telegram](https://t.me/ThePoudyn)

News : [Telegram Channel](https://t.me/IPouDyn)
