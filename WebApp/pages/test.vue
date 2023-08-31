<template>
    <main>
      <ContentList path="/" v-slot="{ list }">
        <div v-for="article in list" :key="article._path">
          <p>{{ article }}</p>
        </div>
      </ContentList>
    </main>
  </template>