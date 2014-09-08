# -*- encoding: utf-8 -*-

Gem::Specification.new do |s|
  s.name = "yml_reader"
  s.version = "0.3"

  s.required_rubygems_version = Gem::Requirement.new(">= 0") if s.respond_to? :required_rubygems_version=
  s.authors = ["Jeffrey S. Morgan"]
  s.date = "2014-06-01"
  s.description = "Sets a directory and reads yml files"
  s.email = ["jeff.morgan@leandog.com"]
  s.homepage = "http://github.com/cheezy/yml_reader"
  s.require_paths = ["lib"]
  s.rubygems_version = "1.8.28"
  s.summary = "Sets a directory and reads yml files"

  if s.respond_to? :specification_version then
    s.specification_version = 4

    if Gem::Version.new(Gem::VERSION) >= Gem::Version.new('1.2.0') then
    else
    end
  else
  end
end
