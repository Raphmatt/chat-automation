namespace WA_automator_logic;

public interface ISend_Mesg
{
    string Send_message_Now(string person, string message);
    
    string Send_message_Later(string person, string message, DateTime sendDate);
}