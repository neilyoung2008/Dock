﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;
using AvaloniaDemo.ViewModels.Documents;
using AvaloniaDemo.ViewModels.Tools;
using AvaloniaDemo.ViewModels.Views;
using Dock.Avalonia.Controls;
using Dock.Model;
using Dock.Model.Controls;

namespace AvaloniaDemo.ViewModels
{
    /// <inheritdoc/>
    public class DemoDockFactory : DockFactory
    {
        /// <inheritdoc/>
        public override IDock CreateLayout()
        {
            // Documents

            var document1 = new Document1
            {
                Id = "Document1",
                Title = "Document1"
            };

            var document2 = new Document2
            {
                Id = "Document2",
                Title = "Document2"
            };

            var document3 = new Document3
            {
                Id = "Document3",
                Title = "Document3"
            };

            // Left / Top

            var leftTopTool1 = new LeftTopTool1
            {
                Id = "LeftTop1",
                Title = "LeftTop1"
            };

            var leftTopTool2 = new LeftTopTool2
            {
                Id = "LeftTop2",
                Title = "LeftTop2"
            };

            var leftTopTool3 = new LeftTopTool3
            {
                Id = "LeftTop3",
                Title = "LeftTop3"
            };

            // Left / Bottom

            var leftBottomTool1 = new LeftBottomTool1
            {
                Id = "LeftBottom1",
                Title = "LeftBottom1"
            };

            var leftBottomTool2 = new LeftBottomTool2
            {
                Id = "LeftBottom2",
                Title = "LeftBottom2"
            };

            var leftBottomTool3 = new LeftBottomTool3
            {
                Id = "LeftBottom3",
                Title = "LeftBottom3"
            };

            // Right / Top

            var rightTopTool1 = new RightTopTool1
            {
                Id = "RightTop1",
                Title = "RightTop1"
            };

            var rightTopTool2 = new RightTopTool2
            {
                Id = "RightTop2",
                Title = "RightTop2"
            };

            var rightTopTool3 = new RightTopTool3
            {
                Id = "RightTop3",
                Title = "RightTop3"
            };

            // Right / Bottom

            var rightBottomTool1 = new RightBottomTool1
            {
                Id = "RightBottom1",
                Title = "RightBottom1"
            };

            var rightBottomTool2 = new RightBottomTool2
            {
                Id = "RightBottom2",
                Title = "RightBottom2"
            };

            var rightBottomTool3 = new RightBottomTool3
            {
                Id = "RightBottom3",
                Title = "RightBottom3"
            };

            // Left Pane

            var leftPane = new LayoutDock
            {
                Id = "LeftPane",
                Proportion = double.NaN,
                Orientation = Orientation.Vertical,
                Title = "LeftPane",
                CurrentView = null,
                Views = CreateList<IView>
                (
                    new ToolDock
                    {
                        Id = "LeftPaneTop",
                        Proportion = double.NaN,
                        Title = "LeftPaneTop",
                        CurrentView = leftTopTool1,
                        Views = CreateList<IView>
                        (
                            leftTopTool1,
                            leftTopTool2,
                            leftTopTool3
                        )
                    },
                    new SplitterDock()
                    {
                        Id = "LeftPaneTopSplitter",
                        Title = "LeftPaneTopSplitter"
                    },
                    new ToolDock
                    {
                        Id = "LeftPaneBottom",
                        Proportion = double.NaN,
                        Title = "LeftPaneBottom",
                        CurrentView = leftBottomTool1,
                        Views = CreateList<IView>
                        (
                            leftBottomTool1,
                            leftBottomTool2,
                            leftBottomTool3
                        )
                    }
                )
            };

            // Right Pane

            var rightPane = new LayoutDock
            {
                Id = "RightPane",
                Proportion = double.NaN,
                Orientation = Orientation.Vertical,
                Title = "RightPane",
                CurrentView = null,
                Views = CreateList<IView>
                (
                    new ToolDock
                    {
                        Id = "RightPaneTop",
                        Proportion = double.NaN,
                        Title = "RightPaneTop",
                        CurrentView = rightTopTool1,
                        Views = CreateList<IView>
                        (
                            rightTopTool1,
                            rightTopTool2,
                            rightTopTool3
                        )
                    },
                    new SplitterDock()
                    {
                        Id = "RightPaneTopSplitter",
                        Title = "RightPaneTopSplitter"
                    },
                    new ToolDock
                    {
                        Id = "RightPaneBottom",
                        Proportion = double.NaN,
                        Title = "RightPaneBottom",
                        CurrentView = rightBottomTool1,
                        Views = CreateList<IView>
                        (
                            rightBottomTool1,
                            rightBottomTool2,
                            rightBottomTool3
                        )
                    }
                )
            };

            // Documents

            var documentsPane = new DocumentDock
            {
                Id = "DocumentsPane",
                Proportion = double.NaN,
                Title = "DocumentsPane",
                CurrentView = document1,
                Views = CreateList<IView>
                (
                    document1,
                    document2,
                    document3
                )
            };

            // Main

            var mainLayout = new LayoutDock
            {
                Id = "MainLayout",
                Proportion = double.NaN,
                Orientation = Orientation.Horizontal,
                Title = "MainLayout",
                CurrentView = null,
                Views = CreateList<IView>
                (
                    leftPane,
                    new SplitterDock()
                    {
                        Id = "LeftSplitter",
                        Title = "LeftSplitter"
                    },
                    documentsPane,
                    new SplitterDock()
                    {
                        Id = "RightSplitter",
                        Title = "RightSplitter"
                    },
                    rightPane
                )
            };

            var mainView = new MainView
            {
                Id = "Main",
                Title = "Main",
                CurrentView = mainLayout,
                Views = CreateList<IView>
                (
                   mainLayout
                )
            };

            // Home

            var homeView = new HomeView
            {
                Id = "Home",
                Title = "Home"
            };

            // Root

            var root = new RootDock
            {
                Id = "Root",
                Title = "Root",
                CurrentView = homeView,
                DefaultView = homeView,
                Views = CreateList<IView>(homeView, mainView)
            };

            return root;
        }

        /// <inheritdoc/>
        public override void InitLayout(IView layout, object context)
        {
            this.ContextLocator = new Dictionary<string, Func<object>>
            {
                // Defaults
                [nameof(IRootDock)] = () => context,
                [nameof(ILayoutDock)] = () => context,
                [nameof(IDocumentDock)] = () => context,
                [nameof(IToolDock)] = () => context,
                [nameof(ISplitterDock)] = () => context,
                [nameof(IDockWindow)] = () => context,
                [nameof(IDocumentTab)] = () => context,
                [nameof(IToolTab)] = () => context,
                // Documents
                ["Document1"] = () => context,
                ["Document2"] = () => context,
                ["Document3"] = () => context,
                // Tools
                ["LeftTop1"] = () => context,
                ["LeftTop2"] = () => context,
                ["LeftTop3"] = () => context,
                ["LeftBottom1"] = () => context,
                ["LeftBottom2"] = () => context,
                ["LeftBottom3"] = () => context,
                ["RightTop1"] = () => context,
                ["RightTop2"] = () => context,
                ["RightTop3"] = () => context,
                ["RightBottom1"] = () => context,
                ["RightBottom2"] = () => context,
                ["RightBottom3"] = () => context,
                ["LeftPane"] = () => context,
                ["LeftPaneTop"] = () => context,
                ["LeftPaneTopSplitter"] = () => context,
                ["LeftPaneBottom"] = () => context,
                ["RightPane"] = () => context,
                ["RightPaneTop"] = () => context,
                ["RightPaneTopSplitter"] = () => context,
                ["RightPaneBottom"] = () => context,
                ["DocumentsPane"] = () => context,
                ["MainLayout"] = () => context,
                ["LeftSplitter"] = () => context,
                ["RightSplitter"] = () => context,
                // Layouts
                ["MainLayout"] = () => context,
                // Views
                ["Home"] = () => context,
                ["Main"] = () => context,
                // Editor
                ["Editor"] = () => new LayoutEditorViewModel()
                {
                    Factory = this,
                    Layout = layout
                }
            };

            this.HostLocator = new Dictionary<string, Func<IDockHost>>
            {
                [nameof(IDockWindow)] = () => new HostWindow()
            };

            base.InitLayout(layout, context);
        }
    }
}
