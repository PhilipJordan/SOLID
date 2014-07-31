# -*- encoding: utf-8 -*-

Gem::Specification.new do |s|
  s.name = "page_navigation"
  s.version = "0.9"

  s.required_rubygems_version = Gem::Requirement.new(">= 0") if s.respond_to? :required_rubygems_version=
  s.authors = ["Jeffrey S. Morgan"]
  s.date = "2013-05-03"
  s.description = "Provides basic navigation through a collection of items that use the PageObject pattern."
  s.email = ["jeff.morgan@leandog.com"]
  s.homepage = "http://github.com/cheezy/page_navigation"
  s.require_paths = ["lib"]
  s.rubyforge_project = "page_naigation"
  s.rubygems_version = "1.8.28"
  s.summary = "Provides basic navigation through a collection of items that use the PageObject pattern."

  if s.respond_to? :specification_version then
    s.specification_version = 4

    if Gem::Version.new(Gem::VERSION) >= Gem::Version.new('1.2.0') then
      s.add_runtime_dependency(%q<data_magic>, [">= 0.14"])
      s.add_development_dependency(%q<rspec>, [">= 2.12.0"])
    else
      s.add_dependency(%q<data_magic>, [">= 0.14"])
      s.add_dependency(%q<rspec>, [">= 2.12.0"])
    end
  else
    s.add_dependency(%q<data_magic>, [">= 0.14"])
    s.add_dependency(%q<rspec>, [">= 2.12.0"])
  end
end
