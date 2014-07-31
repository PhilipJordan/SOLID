# YmlReader

Simple (very simple) gem to set a directory and load yaml files.  This gem is a result of finding duplication between my data_magic and fig_newton gems.  Here's an example of how it is used in the fig_newton gem:

First of all you need to extend the `YmlReader` gem if you intend to use it in another Module:

````ruby
class FigNewton
  extend YmlReader
````

By extending the `YmlReader` module you now have three new methods and two instance variables. Here are the three methods:

````ruby
yml_directory=
yml_directory
load
````

and the instance variables:

````ruby
@yml_directory
@yml
````

The `@yml` instance variable will contain the contents of the yml file after a call to load.

## Installation

Add this line to your application's Gemfile:

    gem 'yml_reader'

And then execute:

    $ bundle

Or install it yourself as:

    $ gem install yml_reader

## Contributing

1. Fork it
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Added some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create new Pull Request
