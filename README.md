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
