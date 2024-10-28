using GitHubActivityCLI.Commands.GitHubEvents;
using GitHubActivityCLI.Commands.GitHubFeeds;
using GitHubActivityCLI.Commands.GitHubNotifications;
using GitHubActivityCLI.Commands.GitHubStarring;
using GitHubActivityCLI.Commands.GitHubWatching;
using GitHubActivityCLI.Repositories;
using ICommand = GitHubActivityCLI.Interfaces.ICommand;

namespace GitHubActivityCLI
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var eventsRepository = new GitHubEventsRepository();
            var feedsRepository = new GitHubFeedsRepository();
            var notificationsRepository = new GitHubNotificationsRepository();
            var starringRepository = new GitHubStarringRepository();
            var watchingRepository = new GitHubWatchingRepository();

            if (args.Length == 0)
            {
                Console.WriteLine("No command provided.");
                return;
            }

            ICommand? command = null;

            switch (args[0].ToLower())
            {
                case "list-public-events":
                    command = new ListPublicEventsCommand(eventsRepository);
                    break;
                case "list-organization-events":
                    command = new ListOrganizationEventsCommand(eventsRepository);
                    break;
                case "list-repository-events":
                    command = new ListRepositoryEventsCommand(eventsRepository);
                    break;
                case "list-user-events":
                    command = new ListUserEventsCommand(eventsRepository);
                    break;
                case "list-user-organization-events":
                    command = new ListUserOrganizationEventsCommand(eventsRepository);
                    break;
                case "list-user-public-events":
                    command = new ListUserPublicEventsCommand(eventsRepository);
                    break;
                case "list-user-received-events":
                    command = new ListUserReceivedEventsCommand(eventsRepository);
                    break;
                case "list-user-received-public-events":
                    command = new ListUserReceivedPublicEventsCommand(eventsRepository);
                    break;
                case "listpubliceventsrepositoriesnetwork":
                    command = new ListPublicEventsRepositoriesNetworkCommand(eventsRepository);
                    break;
                case "get-feeds":
                    command = new GetFeedsCommand(feedsRepository);
                    break;
                case "list-notifications":
                    command = new ListNotificationsCommand(notificationsRepository);
                    break;
                case "mark-notifications-as-read":
                    command = new MarkNotificationsAsReadCommand(notificationsRepository);
                    break;
                case "get-thread":
                    command = new GetThreadCommand(notificationsRepository);
                    break;
                case "mark-thread-as-read":
                    command = new MarkThreadAsReadCommand(notificationsRepository);
                    break;
                case "mark-thread-as-done":
                    command = new MarkThreadAsDoneCommand(notificationsRepository);
                    break;
                case "set-thread-subscription":
                    command = new SetThreadSubscriptionCommand(notificationsRepository);
                    break;
                case "delete-thread-subscription":
                    command = new DeleteThreadSubscriptionCommand(notificationsRepository);
                    break;
                case "list-repository-notifications":
                    command = new ListRepositoryNotificationsCommand(notificationsRepository);
                    break;
                case "mark-repository-notifications-as-read":
                    command = new MarkRepositoryNotificationsAsReadCommand(notificationsRepository);
                    break;
                case "list-stargazers":
                    command = new ListStargazersCommand(starringRepository);
                    break;
                case "list-user-starred-repositories":
                    command = new ListUserStarredRepositoriesCommand(starringRepository);
                    break;
                case "check-if-repository-is-starred-by-user":
                    command = new CheckIfRepositoryIsStarredByUserCommand(starringRepository);
                    break;
                case "star-repository":
                    command = new StarRepositoryCommand(starringRepository);
                    break;
                case "un-star-repository":
                    command = new UnstarRepositoryCommand(starringRepository);
                    break;
                case "list-repositories-starred-by-user":
                    command = new ListRepositoriesStarredByUserCommand(starringRepository);
                    break;
                case "list-watchers":
                    command = new ListWatchersCommand(watchingRepository);
                    break;
                case "get-repository-subscription":
                    command = new GetRepositorySubscriptionCommand(watchingRepository);
                    break;
                case "set-repository-subscription":
                    command = new SetRepositorySubscriptionCommand(watchingRepository);
                    break;
                case "delete-repository-subscription":
                    command = new DeleteRepositorySubscriptionCommand(watchingRepository);
                    break;
                case "list-repositories-watched-by-user":
                    command = new ListRepositoriesWatchedByUserCommand(watchingRepository);
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    return;
            }

            await command.ExecuteAsync(args.Skip(1).ToArray());
        }
    }
}
