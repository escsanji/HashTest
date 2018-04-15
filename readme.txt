For this question, i dont have much experience in the encryption area thus assuming it is not about reverse engineering the SHA256 algorithms.

It does not solve the problem of collisions so if any 2 input messages produce the same hash, the latter one will be returned in the GET.

On multiple users, it is probably more practical to have a storage per user for storing the hash-to-input dictionary


MessageController.cs has most of the logic while the rest is just start-up.
i have also included the debug folder which can be directly run to test the service under MessageService\ConsoleHost\Debug. You can simply click on 
MessageService.exe to run the service locally under Windows (required .NET framework 4.6). Once the console app is started, you can access the 2 methods via:

(GET)http://localhost:19000/messages/{hash_value}
(POST)http://localhost:19000/messages