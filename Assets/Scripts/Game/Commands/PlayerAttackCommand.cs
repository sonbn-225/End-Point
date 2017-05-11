using strange.extensions.command.impl;

public class PlayerAttackCommand : Command {

	[Inject]
	public IPlayer player { get; set; }

	public override void Execute(){
		player.Fire ();
	}
}
