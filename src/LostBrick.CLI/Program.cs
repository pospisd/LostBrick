using LostBrick.Cli;
using LostBrick.CLI.Api;
using Refit;

var api = RestService.For<ILegoApiClient>("https://d16m5wbro86fg2.cloudfront.net");
var service = new BrickService(api);



/// TODO Which sets can the user brickfan35 build with their exisiting inventory of pieces?
/// Total time: 92min
var sets = await service.FindBuildableSets("brickfan35");
Console.WriteLine("User [brickfan35] can build:");
foreach (var setName in sets) Console.WriteLine($"  * {setName}");
Console.WriteLine();


/* TODO
 * The user landscape-artist doesn't have the right pieces to build the set tropical-island. Which
 * users could they combine their collection with to have the complete piece requirements for the build?
 * 
 * Total time: 131min
 */
var buddies = await service.FindBuddyToBuild("landscape-artist", "tropical-island");
Console.WriteLine("User [landscape-artist] can build [tropical-island] with help from:");
foreach (var username in buddies) Console.WriteLine($"  * {username}");
Console.WriteLine();


/* TODO
 * The user megabuilder99 is interested in creating a new custom build but they want to make
 * sure other people could complete it with their current inventories. What collection of pieces
 * should they restrict themselves to if they want to ensure that at least 50% of other users could
 * complete the build?
 * 
 * Total time: 147min (just brainstorming)
*/



/* TODO 
 * The user dr_crocodile wants to expand the number of sets they can build with their current
 * inventory and are prepared to be flexible on the colour scheme. They are happy to substitute
 * any colour in a set as long as all the pieces of that colour are substituted, and that
 * the new colour isn't used elsewhere in the set. For example, a building with white walls,
 * a red roof and a green flag could be built with red walls, a blue roof and a green flag. What
 * new sets can dr_crocodile build by allowing colour substitutions? 
 */



/* TODO 
 * The user dr_crocodile wants to expand the number of sets they can build with their current
 * inventory and are prepared to be flexible on the colour scheme. They are happy to substitute
 * any colour in a set as long as all the pieces of that colour are substituted, and that the new
 * colour isn't used elsewhere in the set. For example, a building with white walls, a red roof
 * and a green flag could be built with red walls, a blue roof and a green flag. What new sets can
 * dr_crocodile build by allowing colour substitutions?
 */

