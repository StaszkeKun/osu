// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Game.Screens.OnlinePlay.Lounge.Components;
using osu.Game.Users;

namespace osu.Game.Tests.Visual.Multiplayer
{
    public class TestSceneRankRangePill : MultiplayerTestScene
    {
        [SetUp]
        public new void Setup() => Schedule(() =>
        {
            Child = new RankRangePill
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            };
        });

        [Test]
        public void TestSingleUser()
        {
            AddStep("add user", () =>
            {
                Client.AddUser(new User
                {
                    Id = 2,
                    Statistics = { GlobalRank = 1234 }
                });

                // Remove the local user so only the one above is displayed.
                Client.RemoveUser(API.LocalUser.Value);
            });
        }

        [Test]
        public void TestMultipleUsers()
        {
            AddStep("add users", () =>
            {
                Client.AddUser(new User
                {
                    Id = 2,
                    Statistics = { GlobalRank = 1234 }
                });

                Client.AddUser(new User
                {
                    Id = 3,
                    Statistics = { GlobalRank = 3333 }
                });

                Client.AddUser(new User
                {
                    Id = 4,
                    Statistics = { GlobalRank = 4321 }
                });

                // Remove the local user so only the ones above are displayed.
                Client.RemoveUser(API.LocalUser.Value);
            });
        }
    }
}
