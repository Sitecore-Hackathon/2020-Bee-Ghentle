![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo")

# Our documentation

## Module purpose
We created this site as a global SUG platform, where every local SUG communities can be managed with their events.
People should be able to register & log in to subscribe to the events.

## Sitecore Hackathon Category
We shose the Sitecore Meetup Website as our submission topic.

- Sitecore Meetup Website – In recent events the Meetup.com site began charging for the registering and hosting of meetings as well as other features previously free. Many of the Sitecore User Groups rely on Meetup

## How does the end user use the module?

### The Home page

1. The main navigation (repeated on all pages)

  - The main logo of the website that always links to the homepage

  - The breadcrumb navigation that shows where you are and allows you to navigate back

2. The Register/Login flow

  - Here people can log in or register so they can login.

  - It will take the users to a form where they can give the needed info

3. The facet search that can be used to filter the user groups by region

  - A facet search that is used to search for usergroups in certain regions

4. The Search results list with all the user groups defined in Sitecore

  - A filterable results list that shows the user groups

5. (not on image) We also have a list that shows a logged-in user's subscribed events.

![Example of the home page](/documentation/images/Homepage.png)

### Usergroup pages

1. The Page title that is reused on all pages

2. A place where we can use richtext content to give more info about the usergroup

3. The first event that is comming for the given user group

  - with all event data such as the title, the date, the location & the speakers

4. All the planned events for the given user group

  - with all event data such as the title, the date, the location & the speakers

![Example of the Usergroup detail page](/documentation/images/UserGroupDetailPage.png)

### Event pages

1. Event details component

  - These event details can be attached:
  - The time and date of the event
  - The location of the event
  - How many seats are left
  - A extra link (might be used for recorded sessions etc.)

2. The sessions list

  - An event can have multiple sessions attached.
  - Each session Has a title, a field to show how long it would take, a place to put more info in rte and 1 or more speakers.
  - Each speaker can have a short bio & an image.

3. (Not in image) We also have a subscribe button

4. (Not in image) We also have a subscribed attendees list

![Example of the Event detail page](/documentation/images/EventDetailPage.png)