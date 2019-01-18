USE e2rm_dev
GO

CREATE PROCEDURE AllEvents
AS
	SELECT e.EventID, e.OrganizationID
	FROM Event e
	ORDER BY e.EventID
GO

ALTER PROCEDURE ContainerByEvent
	@EvenID INTEGER, @PageType varchar(25)
AS
	SELECT c.EventID, c.ContainerID, c.P2PPageTypeID, c.Properties, c.IsHero, c.IsHeroLocked, c.SortOrder, c.ColumnOrder
	FROM P2PContainer c
	WHERE c.EventID = @EvenID and c.P2PPageTypeID = "DonationThankYou"
GO

CREATE PROCEDURE ContainerContentByContainer
	@ContainerID INTEGER
AS
	SELECT c.ContainerID, c.LanguageCode, c.Content
	FROM P2PContainerContent c
	WHERE c.ContainerID = @ContainerID
GO

ALTER PROCEDURE WidgetByContainer
	@ContainerID INTEGER
AS
	SELECT w.WidgetID, w.Locked, w.Properties, w.SortOrder, w.P2PWidgetTypeID, t.Documentation, w.IsRequired, w.IsVisible, w.VisibilityConditionTypeID
	FROM P2PWidget w
	INNER JOIN P2PWidgetType t ON w.P2PWidgetTypeID = t.P2PWidgetTypeID
	WHERE W.ContainerID = @ContainerID
GO

CREATE PROCEDURE WidgetContentByWidget
	@WidgetID INTEGER
AS
	SELECT w.WidgetID, w.LanguageCode, w.Content
	FROM P2PWidgetContent w
	WHERE w.WidgetID = @WidgetID
GO

CREATE PROCEDURE EventByID
	@EvenID INTEGER
AS
	SELECT e.EventID, e.OrganizationID
	FROM Event e
	WHERE e.EventId = @EvenID
GO

CREATE PROCEDURE AllContainers
AS
	SELECT c.ContainerID, c.EventID, c.P2PPageTypeID, c.Properties, c.IsHero, c.IsHeroLocked, c.SortOrder, c.ColumnOrder
	FROM P2PContainer c

CREATE PROCEDURE AllWidgets
AS
	SELECT w.WidgetID, w.Locked, w.Properties, w.SortOrder, w.P2PWidgetTypeID, t.Documentation, w.IsRequired, w.IsVisible, w.VisibilityConditionTypeID, w.ContainerID
	FROM P2PWidget w
	INNER JOIN P2PWidgetType t ON w.P2PWidgetTypeID = t.P2PWidgetTypeID

EXECUTE ContainerByEvent 20519;
EXECUTE ContainerContentByContainer 15;
EXECUTE WidgetByContainer 15;
EXECUTE WidgetContentByWidget 27;
EXECUTE EventByID 389;
EXECUTE EventByID 389;
EXECUTE AllContainers;
EXECUTE AllWidgets;

select * from P2PContainer



select * from P2PWidget 