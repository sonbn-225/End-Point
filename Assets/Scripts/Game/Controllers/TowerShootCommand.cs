using strange.extensions.command.impl;

public class TowerShootCommand : Command {

	[Inject]
	public ITower player { get; set; }

	public override void Execute(){
//		player.Fire ();
	}
}
